using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class VcsRootLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.VcsRootLocator
        {
            Id = "MyVcsRoot",
            InternalId = 3,
            Name = "My Root",
            Type = "jetbrains.git",
            Uuid = "abc-123",
            LookupLimit = 10,
            PageStart = 2,
            PageCount = 4
        };

        sut.ToString().Should().Be("id:MyVcsRoot,internalId:3,name:My Root,type:jetbrains.git,uuid:abc-123,lookupLimit:10,start:2,count:4");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.VcsRootLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Root" },
            Project = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Parent" },
            Property = new Dzaba.TeamCityClient.Locators.LocatorProperty<VcsRootLocatorProperty>("url", "github", VcsRootLocatorProperty.Contains)
        };

        sut.ToString().Should().Be("affectedProject:(id:Root),project:(id:Parent),property:(name:url,value:github,matchType:contains)");
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.VcsRootLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.VcsRootLocator { Name = "First" },
                new Dzaba.TeamCityClient.Locators.VcsRootLocator { Id = "Second" }
            ]
        };

        sut.ToString().Should().Be("item:(name:First),item:(id:Second)");
    }
}
