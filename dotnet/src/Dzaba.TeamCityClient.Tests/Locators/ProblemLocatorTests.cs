using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class ProblemLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.ProblemLocator
        {
            Id = 8,
            Identity = "TC_EXIT_CODE",
            Type = "TC_EXIT_CODE",
            CurrentlyFailing = true,
            CurrentlyInvestigated = false,
            CurrentlyMuted = true,
            LookupLimit = 10,
            PageStart = 1,
            PageCount = 2
        };

        sut.ToString().Should().Be("id:8,identity:TC_EXIT_CODE,type:TC_EXIT_CODE,currentlyFailing:true,currentlyInvestigated:false,currentlyMuted:true,lookupLimit:10,start:1,count:2");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.ProblemLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            Build = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 5 }
        };

        sut.ToString().Should().Be("affectedProject:(id:Proj),build:(id:5)");
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.ProblemLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.ProblemLocator { Id = 1 },
                new Dzaba.TeamCityClient.Locators.ProblemLocator { Type = "X" }
            ]
        };

        sut.ToString().Should().Be("item:(id:1),item:(type:X)");
    }
}
