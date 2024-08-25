using Dzaba.TeamCityClient.Model;

namespace Dzaba.TeamCityClient.Linq;

/// <summary>
/// TeamCity LINQ context
/// </summary>
public interface ITeamCityContext : IDisposable
{
    /// <summary>
    /// TeamCity builds.
    /// </summary>
    IQueryable<Build> Builds { get; }
}

internal sealed class TeamCityContext : ITeamCityContext
{
    private readonly BuildsQueryProvider buildsQueryProvider;

    public TeamCityContext(ITeamCityClient client)
    {
        buildsQueryProvider = new BuildsQueryProvider(client);
    }

    public void Dispose()
    {

    }

    public IQueryable<Build> Builds => new TeamCityQueryable<Build>(buildsQueryProvider);
}
