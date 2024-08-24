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

        return new Model.TeamCityClient(httpClientManager.HttpClient, loggerFactory.CreateLogger<Model.TeamCityClient>(), options.Token)
        {
            BaseUrl = options.Url.ToString()
        };
    }
}