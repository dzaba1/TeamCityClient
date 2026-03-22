using System.Net.Http.Headers;

namespace Dzaba.TeamCityClient;

/// <summary>
/// TeamCity client implementation.
/// </summary>
public partial class TeamCityClient
{
    private readonly string token;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="httpClient">HTTP client object,</param>
    /// <param name="token">TeamCity auth token</param>
    public TeamCityClient(HttpClient httpClient,
        string token)
        : this(httpClient)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentException.ThrowIfNullOrWhiteSpace(token);

        this.token = token;
    }

    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}
