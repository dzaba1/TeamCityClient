using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class DeploymentDashboardLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.DeploymentDashboardLocator
        {
            Id = "dash-1",
            Name = "Prod",
            PageStart = 1,
            PageCount = 2
        };

        sut.ToString().Should().Be("id:dash-1,name:Prod,start:1,count:2");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.DeploymentDashboardLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Root" },
            Project = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" }
        };

        sut.ToString().Should().Be("affectedProject:(id:Root),project:(id:Proj)");
    }
}
