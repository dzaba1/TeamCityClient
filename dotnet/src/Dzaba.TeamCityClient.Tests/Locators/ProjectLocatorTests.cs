using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class ProjectLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.ProjectLocator
        {
            Id = "MyProject",
            Name = "My Project",
            Uuid = "abc-123",
            Archived = false,
            Virtual = true,
            PageStart = 2,
            PageCount = 3
        };

        sut.ToString().Should().Be("id:MyProject,name:My Project,uuid:abc-123,archived:false,virtual:true,start:2,count:3");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.ProjectLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Root" },
            Project = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Parent" },
            ProjectFeature = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Feature" },
            Build = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 5 },
            BuildType = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Bt1" },
            DefaultTemplate = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Name = "Tpl" },
            Pool = new Dzaba.TeamCityClient.Locators.AgentPoolLocator { Id = 1 },
            VcsRoot = new Dzaba.TeamCityClient.Locators.VcsRootLocator { Id = "Vcs" }
        };

        sut.ToString().Should().Be("affectedProject:(id:Root),project:(id:Parent),projectFeature:(id:Feature),build:(id:5),buildType:(id:Bt1),defaultTemplate:(name:Tpl),pool:(id:1),vcsRoot:(id:Vcs)");
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.ProjectLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.ProjectLocator { Name = "First" },
                new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Second" }
            ]
        };

        sut.ToString().Should().Be("item:(name:First),item:(id:Second)");
    }
}
