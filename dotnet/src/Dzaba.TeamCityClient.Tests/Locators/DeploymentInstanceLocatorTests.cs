using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class DeploymentInstanceLocatorTests
{
    [Test]
    public void ToString_WhenCurrentStateIsSet_ThenItIsWrittenAsEnumMemberValue()
    {
        var sut = new Dzaba.TeamCityClient.Locators.DeploymentInstanceLocator
        {
            Id = "inst-1",
            CurrentState = DeploymentInstanceLocatorCurrentState.In_progress,
            PageStart = 1,
            PageCount = 2
        };

        sut.ToString().Should().Be("id:inst-1,currentState:in_progress,start:1,count:2");
    }

    [Test]
    public void ToString_WhenDashboardIsSet_ThenItIsFormattedAsNestedLocator()
    {
        var sut = new Dzaba.TeamCityClient.Locators.DeploymentInstanceLocator
        {
            Id = "inst-1",
            Dashboard = new Dzaba.TeamCityClient.Locators.DeploymentDashboardLocator { Id = "dash-1" }
        };

        sut.ToString().Should().Be("id:inst-1,dashboard:(id:dash-1)");
    }
}
