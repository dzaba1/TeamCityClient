using Dzaba.TeamCityClient.Policy;
using Microsoft.Extensions.DependencyInjection;

namespace Dzaba.TeamCityClient;

/// <summary>
/// DI bootstrapper
/// </summary>
public static class Bootstrapper
{
    /// <summary>
    /// Registers TeamCity services.
    /// </summary>
    /// <param name="services">Services</param>
    public static void RegisterDzabaTeamCityClient(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        services.AddSingleton<IHttpPolicy, HttpPolicy>();
        services.AddSingleton<ITeamCityHttpClientManager, TeamCityHttpClientManager>();
        services.AddTransient<ITeamCityClientFactory, TeamCityClientFactory>();
    }
}
