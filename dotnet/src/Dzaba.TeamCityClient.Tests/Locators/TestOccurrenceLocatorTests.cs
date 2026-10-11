using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class TestOccurrenceLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.TestOccurrenceLocator
        {
            Id = "12",
            Name = "MyTest",
            Status = TestOccurrenceLocatorStatus.Failure,
            Ignored = false,
            IncludePersonal = true,
            Muted = false,
            NewFailure = true,
            CurrentlyFailing = true,
            CurrentlyInvestigated = false,
            CurrentlyMuted = false,
            LookupLimit = 10,
            PageStart = 1,
            PageCount = 2
        };

        sut.ToString().Should().Be("id:12,name:MyTest,status:failure,ignored:false,includePersonal:true,muted:false,newFailure:true,currentlyFailing:true,currentlyInvestigated:false,currentlyMuted:false,lookupLimit:10,start:1,count:2");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.TestOccurrenceLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            Branch = new Dzaba.TeamCityClient.Locators.BranchLocator { SingleValue = "main" },
            Build = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 5 },
            BuildType = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Bt1" },
            Test = new Dzaba.TeamCityClient.Locators.TestLocator { Name = "T" }
        };

        sut.ToString().Should().Be("affectedProject:(id:Proj),branch:(main),build:(id:5),buildType:(id:Bt1),test:(name:T)");
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.TestOccurrenceLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.TestOccurrenceLocator { Name = "A" },
                new Dzaba.TeamCityClient.Locators.TestOccurrenceLocator { Status = TestOccurrenceLocatorStatus.Success }
            ]
        };

        sut.ToString().Should().Be("item:(name:A),item:(status:success)");
    }
}
