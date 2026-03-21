namespace Dzaba.TeamCityClient;

internal interface ITeamCityHttpClientManager : IDisposable
{
    public HttpClient GetClient();
}

internal sealed class TeamCityHttpClientManager : ITeamCityHttpClientManager
{
    private readonly Lazy<HttpClient> httpClient;

    public TeamCityHttpClientManager()
    {
        httpClient = new Lazy<HttpClient>(() => new HttpClient());
    }

    public void Dispose()
    {
        if (httpClient.IsValueCreated)
        {
            httpClient.Value.Dispose();
        }
    }

    public HttpClient GetClient()
    {
        return httpClient.Value;
    }
}
