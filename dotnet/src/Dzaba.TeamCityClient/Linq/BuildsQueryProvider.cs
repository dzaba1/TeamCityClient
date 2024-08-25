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

        if (visitor.Members.Any())
        {
            var props = visitor.Members
                .Select(PropWithName.FromJsonProperty)
                .Where(p => !string.IsNullOrWhiteSpace(p.Name));

            return $"build({Fields.BuildFieldsString(props)})";
        }

        return $"build({Fields.GetSimpleFields<Build>()})";
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

    public override IAsyncEnumerable<T> ExecuteAsyncEnumerable<T>(Expression expression, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(expression, nameof(expression));

        throw new NotImplementedException();
    }

    public override IEnumerable<T> ExecuteEnumerable<T>(Expression expression)
    {
        ArgumentNullException.ThrowIfNull(expression, nameof(expression));

        var builds = ExecuteBuilds(expression).ToArrayAsync().Result;
        //return builds.AsQueryable().Provider.CreateQuery<T>(expression);
        return builds.Cast<T>();
    }
}
