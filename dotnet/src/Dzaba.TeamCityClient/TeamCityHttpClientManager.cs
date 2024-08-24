using Dzaba.TeamCityClient.Policy;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Dzaba.TeamCityClient;

internal interface ITeamCityHttpClientManager : IDisposable
{
    public HttpClient GetClient(PolicySettings policySettings, Uri url);
}

internal sealed class TeamCityHttpClientManager : ITeamCityHttpClientManager
{
    private readonly ILogger<TeamCityHttpClientManager> logger;
    private readonly ConcurrentDictionary<string, HttpClient> clients = new ConcurrentDictionary<string, HttpClient>(StringComparer.OrdinalIgnoreCase);
    private readonly IHttpPolicyBuilder policyBuilder;

    public TeamCityHttpClientManager(ILogger<TeamCityHttpClientManager> logger,
        IHttpPolicyBuilder policyBuilder)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(policyBuilder, nameof(policyBuilder));

        this.logger = logger;
        this.policyBuilder = policyBuilder;
    }

    public HttpClient GetClient(PolicySettings policySettings, Uri url)
    {
        ArgumentNullException.ThrowIfNull(url, nameof(url));

        return clients.GetOrAdd(url.ToString(), u =>
        {
            logger.LogDebug("Creating a new HTTP client for {Url}", u);
            var retryHandler = new HttpRetryMessageHandler(new HttpClientHandler(), policyBuilder, policySettings, u);
            return new HttpClient(retryHandler);
        });
    }

    public void Dispose()
    {
        foreach (var client in clients.Values)
        {
            client.Dispose();
        }
    }
}
