using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Serilog;

namespace Dzaba.TeamCityClient.Tests;

[TestFixture]
public class ResolveTests
{
    private ServiceProvider CreateContainer()
    {
        var services = new ServiceCollection();

        var logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        services.AddLogging(l => l.AddSerilog(logger, true));

        services.RegisterDzabaTeamCityClient();
        return services.BuildServiceProvider();
    }

    [TestCase(typeof(ITeamCityClientFactory))]
    public void GetRequiredService_WhenTypeProvided_ThenServiceIsResolved(Type serviceType)
    {
        using var container = CreateContainer();
        var service = container.GetRequiredService(serviceType);
        service.Should().NotBeNull();
    }

    [Test]
    public void TeamCityClientFactory_WhenFactoryResolved_ThenClientCanBeCreated()
    {
        using var container = CreateContainer();
        var factory = container.GetRequiredService<ITeamCityClientFactory>();
        var client = factory.CreateClient(new TeamCityClientOptions());
        client.Should().NotBeNull();
    }
}
