using Dzaba.TeamCityClient.Model;
using System.Linq.Expressions;

namespace Dzaba.TeamCityClient.Linq;

internal sealed class BuildsQueryProvider : BaseQueryProvider
{
    private readonly ITeamCityClient client;

    public BuildsQueryProvider(ITeamCityClient client)
    {
        ArgumentNullException.ThrowIfNull(client, nameof(client));

        this.client = client;
    }

    public override object Execute(Expression expression)
    {
        ArgumentNullException.ThrowIfNull(expression, nameof(expression));

        throw new NotImplementedException();
    }

    private IAsyncEnumerable<Build> ExecuteBuilds(Expression expression)
    {
        var locator = ParseLocator(expression);
        var fields = ParseFields(expression);
        var itemsPerPage = ParseItemsPerPage(expression);

        return TeamCityPageExpander.GetAllAsync(l => GetBuildsPageAsync(l, fields), locator, itemsPerPage);
    }

    private async IAsyncEnumerable<Build> GetBuildsPageAsync(Locator locator, string fields)
    {
        var resp = await client.GetAllBuildsAsync(locator.ToString(), fields).ConfigureAwait(false);
        foreach (var b in resp.Build)
        {
            yield return b;
        }
    }

    private int ParseItemsPerPage(Expression expression)
    {
        return 100;
    }

    private string ParseFields(Expression expression)
    {
        var visitor = new BuildsExpressionVisitor();
        visitor.Visit(expression);

        var root = visitor.MemberRoots
            .Where(r => r.Type == typeof(Build))
            .ToArray();

        if (root.Any())
        {
            if (root.Length > 1)
            {
                throw new InvalidOperationException("Multiple Build found.");
            }

            return $"build({ParseFields(root[0], visitor)})";
        }

        return $"build({Fields.GetSimpleFields<Build>()})";
    }

    private string ParseFields(ParameterExpression root, BuildsExpressionVisitor visitor)
    {
        var children = visitor.GetChildren(root);

        var items = children
            .Select(e => ParseFields(e, visitor));
        return string.Join(',', items);
    }

    private string ParseFields(MemberExpression member, BuildsExpressionVisitor visitor)
    {
        var children = visitor.GetChildren(member).ToArray();
        var prop = PropWithName.FromJsonProperty(member.Member);

        if (children.Any())
        {
            var items = children
                .Select(e => ParseFields(e, visitor));
            var fields = string.Join(",", items);
            return $"{prop.Name}({fields})";
        }

        return prop.Name;
    }

    private Locator ParseLocator(Expression expression)
    {
        return new Locator
        {
            ["defaultFilter"] = false,
            ["lookupLimit"] = 50000
        };
    }

    public override TResult Execute<TResult>(Expression expression)
    {
        ArgumentNullException.ThrowIfNull(expression, nameof(expression));

        throw new NotImplementedException();
    }

    public override IEnumerable<T> ExecuteEnumerable<T>(Expression expression)
    {
        ArgumentNullException.ThrowIfNull(expression, nameof(expression));

        var builds = ExecuteBuilds(expression).ToArrayAsync().Result
            .AsQueryable();

        var treeCopier = new ExpressionTreeModifier<Build>(builds);
        var newExpressionTree = treeCopier.Visit(expression);

        return builds.Provider.CreateQuery<T>(newExpressionTree);
    }
}
