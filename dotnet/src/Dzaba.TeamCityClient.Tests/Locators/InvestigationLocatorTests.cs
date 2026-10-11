using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class InvestigationLocatorTests
{
    [Test]
    public void ToString_WhenEnumDimensionsAreSet_ThenTheyAreWrittenAsEnumMemberValues()
    {
        var sut = new Dzaba.TeamCityClient.Locators.InvestigationLocator
        {
            State = InvestigationLocatorState.Given_up,
            Resolution = InvestigationLocatorResolution.When_fixed,
            Type = InvestigationLocatorType.AnyProblem,
            PageStart = 1,
            PageCount = 2
        };

        sut.ToString().Should().Be("state:given_up,resolution:when_fixed,type:anyProblem,start:1,count:2");
    }

    [Test]
    public void ToString_WhenSinceDateIsSet_ThenItIsFormattedAsTeamCityDate()
    {
        var sut = new Dzaba.TeamCityClient.Locators.InvestigationLocator
        {
            SinceDate = new DateTimeOffset(2024, 6, 1, 12, 0, 0, TimeSpan.Zero)
        };

        sut.ToString().Should().Be("sinceDate:20240601T120000+0000");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.InvestigationLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            AffectedProjectAndParents = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Root" },
            AssignmentProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Asg" },
            Assignee = new Dzaba.TeamCityClient.Locators.UserLocator { SingleValue = "current" },
            Reporter = new Dzaba.TeamCityClient.Locators.UserLocator { Username = "bob" },
            BuildType = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Bt1" },
            Problem = new Dzaba.TeamCityClient.Locators.ProblemLocator { Id = 8 },
            Test = new Dzaba.TeamCityClient.Locators.TestLocator { Name = "T" }
        };

        sut.ToString().Should().Be("affectedProject:(id:Proj),affectedProjectAndParents:(id:Root),assignmentProject:(id:Asg),assignee:(current),reporter:(username:bob),buildType:(id:Bt1),problem:(id:8),test:(name:T)");
    }
}
