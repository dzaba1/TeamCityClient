using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class BuildQueueLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildQueueLocator
        {
            Id = 7,
            Personal = true,
            PageStart = 1,
            PageCount = 5
        };

        sut.ToString().Should().Be("id:7,personal:true,start:1,count:5");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildQueueLocator
        {
            Agent = new Dzaba.TeamCityClient.Locators.AgentLocator { Name = "DefaultAgent" },
            BuildType = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Bt1" },
            Pool = new Dzaba.TeamCityClient.Locators.AgentPoolLocator { Id = 1 },
            Project = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            User = new Dzaba.TeamCityClient.Locators.UserLocator { SingleValue = "current" }
        };

        sut.ToString().Should().Be("agent:(name:DefaultAgent),buildType:(id:Bt1),pool:(id:1),project:(id:Proj),user:(current)");
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildQueueLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.BuildQueueLocator { Id = 1 },
                new Dzaba.TeamCityClient.Locators.BuildQueueLocator { Personal = false }
            ]
        };

        sut.ToString().Should().Be("item:(id:1),item:(personal:false)");
    }
}
