using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class BuildLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildLocator
        {
            Id = 1,
            Number = "1.2.3",
            AgentTypeId = 4,
            TaskId = 5,
            LookupLimit = 6,
            State = BuildLocatorState.Finished,
            Status = "SUCCESS",
            Revision = "abc",
            PageStart = 7,
            PageCount = 8
        };

        sut.ToString().Should().Be("id:1,number:1.2.3,agentTypeId:4,taskId:5,lookupLimit:6,state:finished,status:SUCCESS,revision:abc,start:7,count:8");
    }

    [Test]
    public void ToString_WhenBooleanDimensionsAreSet_ThenTheyAreLowerCase()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildLocator
        {
            DefaultFilter = false,
            Personal = true,
            Pinned = false
        };

        sut.ToString().Should().Be("defaultFilter:false,personal:true,pinned:false");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildLocator
        {
            BuildType = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Bt1" },
            Agent = new Dzaba.TeamCityClient.Locators.AgentLocator { Name = "DefaultAgent" },
            User = new Dzaba.TeamCityClient.Locators.UserLocator { SingleValue = "current" }
        };

        sut.ToString().Should().Be("buildType:(id:Bt1),agent:(name:DefaultAgent),user:(current)");
    }

    [Test]
    public void ToString_WhenDateDimensionIsSet_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildLocator
        {
            FinishDate = new Dzaba.TeamCityClient.Locators.BuildDateLocator
            {
                Date = new DateTimeOffset(2024, 6, 1, 12, 0, 0, TimeSpan.Zero),
                Condition = "after"
            },
            StartDate = new Dzaba.TeamCityClient.Locators.BuildDateLocator
            {
                Build = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 10 },
                Condition = "before"
            }
        };

        sut.ToString().Should().Be("finishDate:(date:20240601T120000+0000,condition:after),startDate:(build:(id:10),condition:before)");
    }

    [Test]
    public void ToString_WhenPropertyIsSet_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildLocator
        {
            Property = new Dzaba.TeamCityClient.Locators.LocatorProperty<BuildLocatorProperty>("env.OS", "Linux", BuildLocatorProperty.Equals)
        };

        sut.ToString().Should().Be("property:(name:env.OS,value:Linux,matchType:equals)");
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 1 },
                new Dzaba.TeamCityClient.Locators.BuildLocator { Number = "2" }
            ]
        };

        sut.ToString().Should().Be("item:(id:1),item:(number:2)");
    }
}
