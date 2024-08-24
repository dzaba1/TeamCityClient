using Dzaba.TeamCityClient.Policy;

namespace Dzaba.TeamCityClient;

/// <summary>
/// All options need to create a TeamCity client instance.
/// </summary>
public sealed class TeamCityClientOptions
{
    /// <summary>
    /// TeamCity server base URL.
    /// </summary>
    public Uri Url { get; set; }

    /// <summary>
    /// TeamCity auth token.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// HTTP retry policy.
    /// </summary>
    public PolicySettings Policy { get; set; } = new PolicySettings
    {
        RetryCount = 2,
        RetryWait = TimeSpan.FromSeconds(3),
    };
}

