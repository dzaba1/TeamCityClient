using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class CloudInstanceLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.CloudInstanceLocator
        {
            Id = "i-123",
            NetworkAddress = "10.0.0.5",
            Property = new Dzaba.TeamCityClient.Locators.LocatorProperty<LocatorPropertyType>("zone", "eu", LocatorPropertyType.StartsWith),
            PageStart = 1,
            PageCount = 2
        };

        sut.ToString().Should().Be("id:i-123,networkAddress:10.0.0.5,property:(name:zone,value:eu,matchType:starts-with),start:1,count:2");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.CloudInstanceLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Root" },
            Project = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            Agent = new Dzaba.TeamCityClient.Locators.AgentLocator { Name = "A1" },
            Image = new Dzaba.TeamCityClient.Locators.CloudImageLocator { Name = "Img" },
            Profile = new Dzaba.TeamCityClient.Locators.CloudProfileLocator { Id = "p1" }
        };

        sut.ToString().Should().Be("affectedProject:(id:Root),project:(id:Proj),agent:(name:A1),image:(name:Img),profile:(id:p1)");
    }
}
