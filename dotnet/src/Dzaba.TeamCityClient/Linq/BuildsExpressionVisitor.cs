using System.Linq.Expressions;
using System.Reflection;

namespace Dzaba.TeamCityClient.Linq;

internal sealed class BuildsExpressionVisitor : ExpressionVisitor
{
    public List<MemberInfo> Members { get; } = [];

    protected override Expression VisitMember(MemberExpression node)
    {
        Members.Add(node.Member);

        return base.VisitMember(node);
    }
}
