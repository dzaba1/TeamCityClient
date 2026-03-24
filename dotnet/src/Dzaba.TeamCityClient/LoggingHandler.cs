using Microsoft.Extensions.Logging;

namespace Dzaba.TeamCityClient;

internal sealed class LoggingHandler : DelegatingHandler
{
    private readonly ILogger<LoggingHandler> _logger;

    public LoggingHandler(ILogger<LoggingHandler> logger)
        : this(logger, new HttpClientHandler())
    {

    }

    public LoggingHandler(ILogger<LoggingHandler> logger, HttpMessageHandler innerHandler)
        : base(innerHandler)
    {
        ArgumentNullException.ThrowIfNull(logger);

        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{Method} {Uri}", request.Method, request.RequestUri);

        if (_logger.IsEnabled(LogLevel.Debug) && request.Content != null)
        {
            var content = await request.Content.ReadAsStringAsync(cancellationToken);
            if (!string.IsNullOrEmpty(content))
            {
                _logger.LogDebug("Request Body: {Body}", content);
            }
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("Response: {StatusCode}", response.StatusCode);

            var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
            if (!string.IsNullOrEmpty(responseBody))
            {
                _logger.LogDebug("Response Body: {Body}", responseBody);
            }
        }

        return response;
    }
}

