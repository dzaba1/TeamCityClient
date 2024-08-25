using Dzaba.TeamCityClient.Linq;
using Dzaba.TeamCityClient.Model;
using Microsoft.Extensions.Logging;

namespace Dzaba.TeamCityClient;

/// <summary>
/// TeamCity client factory.
/// </summary>
public interface ITeamCityClientFactory
{
    /// <summary>
    /// Creates a client for provided TeamCity server.
    /// </summary>
    /// <param name="options">All options need to create a TeamCity client instance.</param>
    /// <returns>TeamCity client.</returns>
    ITeamCityClient CreateClient(TeamCityClientOptions options);

    /// <summary>
    /// Creates a LINQ context for provided TeamCity server.
    /// </summary>
    /// <param name="options">All options need to create a TeamCity client instance.</param>
    /// <returns>TeamCity client context.</returns>
    ITeamCityContext CreateContext(TeamCityClientOptions options);
}

internal sealed class TeamCityClientFactory : ITeamCityClientFactory
{
    private readonly ITeamCityHttpClientManager httpClientManager;
    private readonly ILoggerFactory loggerFactory;

    public TeamCityClientFactory(ITeamCityHttpClientManager httpClientManager,
        ILoggerFactory loggerFactory)
    {
        ArgumentNullException.ThrowIfNull(httpClientManager, nameof(httpClientManager));
        ArgumentNullException.ThrowIfNull(loggerFactory, nameof(loggerFactory));

        this.httpClientManager = httpClientManager;
        this.loggerFactory = loggerFactory;
    }

    public ITeamCityClient CreateClient(TeamCityClientOptions options)
    {
        ArgumentNullException.ThrowIfNull(options, nameof(options));

        var httpClient = httpClientManager.GetClient(options.Policy, options.Url);
        return new Model.TeamCityClient(httpClient, loggerFactory.CreateLogger<Model.TeamCityClient>(), options.Token)
        {
            BaseUrl = options.Url.ToString()
        };
    }

    public ITeamCityContext CreateContext(TeamCityClientOptions options)
    {
        return new TeamCityContext(CreateClient(options));
    }
}