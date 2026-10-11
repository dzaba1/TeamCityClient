using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class TestLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.TestLocator
        {
            Id = 4,
            Name = "MyTest",
            CurrentlyFailing = true,
            CurrentlyInvestigated = false,
            CurrentlyMuted = true,
            LookupLimit = 50,
            PageStart = 1,
            PageCount = 2
        };

        sut.ToString().Should().Be("id:4,name:MyTest,currentlyFailing:true,currentlyInvestigated:false,currentlyMuted:true,lookupLimit:50,start:1,count:2");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.TestLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            Build = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 5 },
            MuteAffected = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Bt1" }
        };

        sut.ToString().Should().Be("affectedProject:(id:Proj),build:(id:5),muteAffected:(id:Bt1)");
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.TestLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.TestLocator { Id = 1 },
                new Dzaba.TeamCityClient.Locators.TestLocator { Name = "B" }
            ]
        };

        sut.ToString().Should().Be("item:(id:1),item:(name:B)");
    }
}
