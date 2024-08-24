namespace Dzaba.TeamCityClient.Policy;

/// <summary>
/// HTTP policy settings
/// </summary>
public sealed class PolicySettings
{
    /// <summary>
    /// Retry count. Set 0 to have no retries.
    /// </summary>
    public int RetryCount { get; set; }

    /// <summary>
    /// Retry wait. Set null to ignore waiting.
    /// </summary>
    public TimeSpan? RetryWait { get; set; }
}
