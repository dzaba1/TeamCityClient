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
    /// Gets or sets the instance of <see cref="HttpClient"/> used to send HTTP requests and receive HTTP responses.
    /// </summary>
    public HttpClient HttpClient { get; set; }
}

