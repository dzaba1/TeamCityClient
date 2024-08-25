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

        var locator = ParseLocator(expression);
        var fields = ParseFields(expression);
        var itemsPerPage = ParseItemsPerPage(expression);

        var builds = TeamCityPageExpander.GetAllAsync(l => GetBuildsPageAsync(l, fields), locator, itemsPerPage);
        return builds.ToArrayAsync().Result;
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

        var props = visitor.Members
            .Select(PropWithName.FromJsonProperty)
            .Where(p => !string.IsNullOrWhiteSpace(p.Name));

        return $"build({Fields.BuildFieldsString(props)})";
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
}
