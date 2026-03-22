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

    public TeamCityClientFactory(ITeamCityHttpClientManager httpClientManager)
    {
        ArgumentNullException.ThrowIfNull(httpClientManager);

        this.httpClientManager = httpClientManager;
    }

    private HttpClient GetHttpClient(TeamCityClientOptions options)
    {
        if (options.HttpClient is not null)
        {
            return options.HttpClient;
        }
        return httpClientManager.GetClient();
    }

    public ITeamCityClient CreateClient(TeamCityClientOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        return new TeamCityClient(GetHttpClient(options), options.Token)
        {
            BaseUrl = options.Url.ToString()
        };
    }
}