using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class VcsRootInstanceLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.VcsRootInstanceLocator
        {
            Id = "12",
            Type = "jetbrains.git",
            VersionedSettings = true,
            LookupLimit = 10,
            PageStart = 2,
            PageCount = 4
        };

        sut.ToString().Should().Be("id:12,type:jetbrains.git,versionedSettings:true,lookupLimit:10,start:2,count:4");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.VcsRootInstanceLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Root" },
            Project = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Parent" },
            Build = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 5 },
            BuildType = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Bt1" },
            VcsRoot = new Dzaba.TeamCityClient.Locators.VcsRootLocator { Id = "Vcs" },
            Property = new Dzaba.TeamCityClient.Locators.LocatorProperty<VcsRootInstanceLocatorProperty>("url", "github", VcsRootInstanceLocatorProperty.Contains)
        };

        sut.ToString().Should().Be("affectedProject:(id:Root),project:(id:Parent),build:(id:5),buildType:(id:Bt1),vcsRoot:(id:Vcs),property:(name:url,value:github,matchType:contains)");
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.VcsRootInstanceLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.VcsRootInstanceLocator { Id = "1" },
                new Dzaba.TeamCityClient.Locators.VcsRootInstanceLocator { Type = "jetbrains.git" }
            ]
        };

        sut.ToString().Should().Be("item:(id:1),item:(type:jetbrains.git)");
    }
}
