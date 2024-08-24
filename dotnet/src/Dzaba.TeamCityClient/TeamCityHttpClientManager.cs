using Dzaba.TeamCityClient.Policy;

namespace Dzaba.TeamCityClient;

internal interface ITeamCityHttpClientManager : IDisposable
{
    public HttpClient HttpClient { get; }
}

internal sealed class TeamCityHttpClientManager : ITeamCityHttpClientManager
{
    public TeamCityHttpClientManager(IHttpPolicy policy)
    {
        ArgumentNullException.ThrowIfNull(policy, nameof(policy));

        var retryHandler = new HttpRetryMessageHandler(new HttpClientHandler(), policy);
        HttpClient = new HttpClient(retryHandler);
    }

    public HttpClient HttpClient { get; }

    public void Dispose()
    {
        HttpClient?.Dispose();
    }
}
