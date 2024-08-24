using Microsoft.Extensions.Logging;
using Polly;

namespace Dzaba.TeamCityClient.Policy;

internal interface IHttpPolicyBuilder
{
    IAsyncPolicy<HttpResponseMessage> Build(PolicySettings settings, string url);
}

internal sealed class HttpPolicyBuilder : IHttpPolicyBuilder
{
    private readonly ILogger<HttpPolicyBuilder> logger;

    public HttpPolicyBuilder(ILogger<HttpPolicyBuilder> logger)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));

        this.logger = logger;
    }

    public IAsyncPolicy<HttpResponseMessage> Build(PolicySettings settings, string url)
    {
        if (settings == null)
        {
            return null;
        }

        var policies = ApplyPolicies(settings);
        return BuildPolicy(policies, url);
    }

    private void OnRetry(DelegateResult<HttpResponseMessage> result, int count, Context context)
    {
        if (result.Exception != null)
        {
            logger.LogWarning(result.Exception, "Some retry. HTTP code: {HttpCode}. Count: {Count}.", result.Result?.StatusCode, count);
        }
        else
        {
            logger.LogWarning("Some retry. HTTP code: {HttpCode}. Count: {Count}.", result.Result?.StatusCode, count);
        }
    }

    private void OnRetry(DelegateResult<HttpResponseMessage> result, TimeSpan sleepDuration, int count, Context context)
    {
        if (result.Exception != null)
        {
            logger.LogWarning(result.Exception, "Some retry with wait. HTTP code: {HttpCode}. Sleep duration: {SleepDuration}. Count: {Count}.", result.Result?.StatusCode, sleepDuration, count);
        }
        else
        {
            logger.LogWarning("Some retry with wait. HTTP code: {HttpCode}. Sleep duration: {SleepDuration}. Count: {Count}.", result.Result?.StatusCode, sleepDuration, count);
        }
    }

    private IEnumerable<IAsyncPolicy<HttpResponseMessage>> ApplyPolicies(PolicySettings policySettings)
    {
        var policyBuilder = Polly.Policy
            .Handle<Exception>()
            .OrResult<HttpResponseMessage>(x => !x.IsSuccessStatusCode);

        if (policySettings.RetryCount > 0)
        {
            if (policySettings.RetryWait.HasValue)
            {
                yield return policyBuilder.WaitAndRetryAsync(policySettings.RetryCount,
                    i => policySettings.RetryWait.Value, OnRetry);
            }
            else
            {
                yield return policyBuilder.RetryAsync(policySettings.RetryCount, OnRetry);
            }
        }
    }

    private IAsyncPolicy<HttpResponseMessage> BuildPolicy(IEnumerable<IAsyncPolicy<HttpResponseMessage>> policies, string url)
    {
        var policiesLocal = policies.ToArray();
        if (policiesLocal.Any())
        {
            var localPolicy = policiesLocal.Length > 1
                ? Polly.Policy.WrapAsync(policiesLocal)
                : policiesLocal[0];

            localPolicy.WithPolicyKey("HttpClient_" + url);
            return localPolicy;
        }

        return null;
    }
}
