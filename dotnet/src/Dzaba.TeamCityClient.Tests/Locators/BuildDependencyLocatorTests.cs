using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class BuildDependencyLocatorTests
{
    [Test]
    public void ToString_WhenSnapshotDependencyHasToAndFrom_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildLocator
        {
            SnapshotDependency = new Dzaba.TeamCityClient.Locators.BuildDependencyLocator
            {
                To = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 1 },
                From = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 2 }
            }
        };

        sut.ToString().Should().Be("snapshotDependency:(to:(id:1),from:(id:2))");
    }

    [Test]
    public void ToString_WhenArtifactDependencyHasOnlyFrom_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildLocator
        {
            ArtifactDependency = new Dzaba.TeamCityClient.Locators.BuildDependencyLocator
            {
                From = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 2 }
            }
        };

        sut.ToString().Should().Be("artifactDependency:(from:(id:2))");
    }
}
