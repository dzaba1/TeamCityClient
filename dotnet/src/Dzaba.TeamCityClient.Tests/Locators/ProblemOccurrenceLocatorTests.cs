using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class ProblemOccurrenceLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.ProblemOccurrenceLocator
        {
            Identity = "TC_EXIT_CODE",
            Type = "TC_EXIT_CODE",
            Muted = true,
            CurrentlyFailing = true,
            CurrentlyInvestigated = false,
            CurrentlyMuted = false,
            LookupLimit = 10,
            PageStart = 1,
            PageCount = 2
        };

        sut.ToString().Should().Be("identity:TC_EXIT_CODE,type:TC_EXIT_CODE,muted:true,currentlyFailing:true,currentlyInvestigated:false,currentlyMuted:false,lookupLimit:10,start:1,count:2");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.ProblemOccurrenceLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            Build = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 5 },
            Problem = new Dzaba.TeamCityClient.Locators.ProblemLocator { Id = 8 }
        };

        sut.ToString().Should().Be("affectedProject:(id:Proj),build:(id:5),problem:(id:8)");
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.ProblemOccurrenceLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.ProblemOccurrenceLocator { Identity = "a" },
                new Dzaba.TeamCityClient.Locators.ProblemOccurrenceLocator { Type = "b" }
            ]
        };

        sut.ToString().Should().Be("item:(identity:a),item:(type:b)");
    }
}
