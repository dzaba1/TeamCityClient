using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class BuildTypeLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildTypeLocator
        {
            Id = "Project_Bt1",
            Name = "MyBuildType",
            Uuid = "abc-123",
            Paused = false,
            TemplateFlag = true,
            PageStart = 2,
            PageCount = 3
        };

        sut.ToString().Should().Be("id:Project_Bt1,name:MyBuildType,uuid:abc-123,paused:false,templateFlag:true,start:2,count:3");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildTypeLocator
        {
            Project = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Root" },
            Build = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 5 },
            Template = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Name = "Tpl" },
            VcsRoot = new Dzaba.TeamCityClient.Locators.VcsRootLocator { Id = "Vcs" },
            VcsRootInstance = new Dzaba.TeamCityClient.Locators.VcsRootInstanceLocator { Id = "7" }
        };

        sut.ToString().Should().Be("project:(id:Proj),affectedProject:(id:Root),build:(id:5),template:(name:Tpl),vcsRoot:(id:Vcs),vcsRootInstance:(id:7)");
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildTypeLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Name = "First" },
                new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Second" }
            ]
        };

        sut.ToString().Should().Be("item:(name:First),item:(id:Second)");
    }
}
