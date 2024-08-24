using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace Dzaba.TeamCityClient.Model;

/// <summary>
/// TeamCity client implementation.
/// </summary>
public partial class TeamCityClient
{
    private readonly ILogger<TeamCityClient> logger;
    private readonly string token;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="httpClient">HTTP client object,</param>
    /// <param name="logger">Logger</param>
    /// <param name="token">TeamCity auth token</param>
    public TeamCityClient(HttpClient httpClient,
        ILogger<TeamCityClient> logger,
        string token)
        : this(httpClient)
    {
        ArgumentNullException.ThrowIfNull(httpClient, nameof(httpClient));
        ArgumentException.ThrowIfNullOrWhiteSpace(token, nameof(token));

        this.logger = logger;
        this.token = token;
    }

    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
    {
        logger.LogInformation("{Method} {Url}", request.Method, url);

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        if (logger.IsEnabled(LogLevel.Debug) && request.Content != null)
        {
            using var stream = request.Content.ReadAsStream();
            using var reader = new StreamReader(stream);
            logger.LogDebug(reader.ReadToEnd());
        }
    }
}
