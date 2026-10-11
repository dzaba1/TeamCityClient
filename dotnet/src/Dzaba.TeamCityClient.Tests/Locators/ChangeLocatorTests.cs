using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class ChangeLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.ChangeLocator
        {
            Id = 3,
            Comment = "fix",
            File = "src/a.cs",
            InternalVersion = "abc123",
            SinceChange = "def456",
            Username = "MyVCSUsername",
            Version = "1.0",
            Pending = true,
            PageStart = 2,
            PageCount = 4
        };

        sut.ToString().Should().Be("id:3,comment:fix,file:src/a.cs,internalVersion:abc123,sinceChange:def456,username:MyVCSUsername,version:1.0,pending:true,start:2,count:4");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.ChangeLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Root" },
            Project = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            Build = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 5 },
            BuildType = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Bt1" },
            User = new Dzaba.TeamCityClient.Locators.UserLocator { SingleValue = "current" },
            VcsRoot = new Dzaba.TeamCityClient.Locators.VcsRootLocator { Id = "Vcs" },
            VcsRootInstance = new Dzaba.TeamCityClient.Locators.VcsRootInstanceLocator { Id = "7" }
        };

        sut.ToString().Should().Be("affectedProject:(id:Root),project:(id:Proj),build:(id:5),buildType:(id:Bt1),user:(current),vcsRoot:(id:Vcs),vcsRootInstance:(id:7)");
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.ChangeLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.ChangeLocator { Id = 1 },
                new Dzaba.TeamCityClient.Locators.ChangeLocator { Username = "bob" }
            ]
        };

        sut.ToString().Should().Be("item:(id:1),item:(username:bob)");
    }
}
