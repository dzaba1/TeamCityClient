using Polly;

namespace Dzaba.TeamCityClient.Policy;

internal sealed class HttpRetryMessageHandler : DelegatingHandler
{
    private readonly Lazy<IAsyncPolicy<HttpResponseMessage>> policy;

    public HttpRetryMessageHandler(HttpClientHandler handler,
        IHttpPolicyBuilder policyBuilder,
        PolicySettings policySettings,
        string url)
        : base(handler)
    {
        ArgumentNullException.ThrowIfNull(policyBuilder, nameof(policyBuilder));

        policy = new Lazy<IAsyncPolicy<HttpResponseMessage>>(() => policyBuilder.Build(policySettings, url));
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (policy.Value == null)
        {
            return await base.SendAsync(request, cancellationToken)
                .ConfigureAwait(false);
        }

        return await policy.Value.ExecuteAsync(async () => await base.SendAsync(request, cancellationToken)
                .ConfigureAwait(false))
            .ConfigureAwait(false);
    }
}
