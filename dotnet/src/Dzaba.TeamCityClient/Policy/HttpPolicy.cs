using Microsoft.Extensions.Logging;
using Polly;

namespace Dzaba.TeamCityClient.Policy;

internal interface IHttpPolicy
{
    Task<HttpResponseMessage> RunAsync(Func<Task<HttpResponseMessage>> action);
}

internal sealed class HttpPolicy : IHttpPolicy
{
    private readonly ILogger<HttpPolicy> logger;
    private readonly Lazy<IAsyncPolicy<HttpResponseMessage>> policy;
    private readonly PolicySettings policySettings;

    public HttpPolicy(ILogger<HttpPolicy> logger, PolicySettings policySettings)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(policySettings, nameof(policySettings));

        this.logger = logger;
        this.policySettings = policySettings;

        policy = new Lazy<IAsyncPolicy<HttpResponseMessage>>(() =>
        {
            var policies = ApplyPolicies();
            return BuildPolicy(policies);
        });
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

    private IEnumerable<IAsyncPolicy<HttpResponseMessage>> ApplyPolicies()
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

    private IAsyncPolicy<HttpResponseMessage> BuildPolicy(IEnumerable<IAsyncPolicy<HttpResponseMessage>> policies)
    {
        var policiesLocal = policies.ToArray();
        if (policiesLocal.Any())
        {
            var localPolicy = policiesLocal.Length > 1
                ? Polly.Policy.WrapAsync(policiesLocal)
                : policiesLocal[0];

            localPolicy.WithPolicyKey("HttpClient");
            return localPolicy;
        }

        return null;
    }

    public async Task<HttpResponseMessage> RunAsync(Func<Task<HttpResponseMessage>> action)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));

        if (policy.Value == null)
        {
            return await action().ConfigureAwait(false);
        }

        return await policy.Value.ExecuteAsync(action)
            .ConfigureAwait(false);
    }
}
