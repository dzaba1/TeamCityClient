using Microsoft.Extensions.Logging;

namespace Dzaba.TeamCityClient;

internal interface ITeamCityHttpClientManager : IDisposable
{
    public HttpClient GetClient();
}

internal sealed class TeamCityHttpClientManager : ITeamCityHttpClientManager
{
    private readonly Lazy<HttpClient> httpClient;
    private readonly ILoggerFactory loggerFactory;

    public TeamCityHttpClientManager(ILoggerFactory loggerFactory)
    {
        ArgumentNullException.ThrowIfNull(loggerFactory);

        this.loggerFactory = loggerFactory;
        httpClient = new Lazy<HttpClient>(CreateHttpClient);
    }

    private HttpClient CreateHttpClient()
    {
        return new HttpClient(new LoggingHandler(loggerFactory.CreateLogger<LoggingHandler>()));
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
