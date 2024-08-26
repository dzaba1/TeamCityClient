using System.Linq.Expressions;
using System.Reflection;

namespace Dzaba.TeamCityClient.Linq;

internal sealed class BuildsExpressionVisitor : ExpressionVisitor
{
    private readonly Dictionary<ParameterExpression, HashSet<MemberExpression>> memberRoots = new Dictionary<ParameterExpression, HashSet<MemberExpression>>();
    private readonly Dictionary<MemberExpression, HashSet<MemberExpression>> memberParents = new Dictionary<MemberExpression, HashSet<MemberExpression>>();
    private readonly HashSet<MemberExpression> membersVisited = new HashSet<MemberExpression>();

    public IEnumerable<ParameterExpression> MemberRoots => memberRoots.Keys;

    protected override Expression VisitMember(MemberExpression node)
    {
        if (!membersVisited.Contains(node))
        {
            VisitMemberInternal(node);
        }

        return base.VisitMember(node);
    }

    private void VisitMemberInternal(MemberExpression node)
    {
        membersVisited.Add(node);

        var parents = EnumerateParents(node)
            .Reverse()
            .ToArray();

        for (var i = 0; i < parents.Length; i++)
        {
            var current = parents[i];
            var next = node;
            if (i < parents.Length - 1)
            {
                next = (MemberExpression)parents[i + 1];
            }

            if (current is ParameterExpression)
            {
                if (!memberRoots.TryGetValue((ParameterExpression)current, out var list))
                {
                    list = new HashSet<MemberExpression>();
                    memberRoots.Add((ParameterExpression)current, list);
                }
                list.Add(next);
            }
            else
            {
                if (!memberParents.TryGetValue((MemberExpression)current, out var list))
                {
                    list = new HashSet<MemberExpression>();
                    memberParents.Add((MemberExpression)current, list);
                }
                list.Add(next);
            }
        }
    }

    public IEnumerable<MemberExpression> GetChildren(ParameterExpression root)
    {
        if (memberRoots.TryGetValue(root, out var list))
        {
            return list;
        }
        return Enumerable.Empty<MemberExpression>();
    }

    public IEnumerable<MemberExpression> GetChildren(MemberExpression element)
    {
        if (memberParents.TryGetValue(element, out var list))
        {
            return list;
        }
        return Enumerable.Empty<MemberExpression>();
    }

    private IEnumerable<Expression> EnumerateParents(MemberExpression node)
    {
        var parent = node.Expression;

        if (parent is MemberExpression)
        {
            yield return parent;
            foreach (var parent2 in EnumerateParents((MemberExpression)parent))
            {
                yield return parent2;
            }
        }
        else if (parent is ParameterExpression)
        {
            yield return parent;
        }
    }
}
