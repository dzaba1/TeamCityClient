namespace Dzaba.TeamCityClient.Policy;

internal sealed class HttpRetryMessageHandler : DelegatingHandler
{
    private readonly IHttpPolicy policy;

    public HttpRetryMessageHandler(HttpClientHandler handler,
        IHttpPolicy policy)
        : base(handler)
    {
        ArgumentNullException.ThrowIfNull(policy, nameof(policy));

        this.policy = policy;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await policy.RunAsync(() => base.SendAsync(request, cancellationToken))
            .ConfigureAwait(false);
    }
}
