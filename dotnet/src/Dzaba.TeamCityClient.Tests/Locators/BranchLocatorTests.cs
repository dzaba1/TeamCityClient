using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class BranchLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BranchLocator
        {
            Name = "main",
            Default = LocatorTriState.True,
            Unspecified = LocatorTriState.False,
            ChangesFromDependencies = LocatorTriState.Any,
            Policy = BranchLocatorPolicy.Active_vcs_branches,
            PageStart = 2,
            PageCount = 4
        };

        sut.ToString().Should().Be("name:main,default:true,unspecified:false,changesFromDependencies:any,policy:active_vcs_branches,start:2,count:4");
    }

    [Test]
    public void ToString_WhenSingleValueIsSet_ThenItIsWrittenWithoutDimensionName()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BranchLocator { SingleValue = "feature/x" };

        sut.ToString().Should().Be("feature/x");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BranchLocator
        {
            Build = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 5 },
            BuildType = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Bt1" }
        };

        sut.ToString().Should().Be("build:(id:5),buildType:(id:Bt1)");
    }

    [Test]
    public void ToString_WhenUsedInBuildLocator_ThenItIsFormattedAsNestedLocator()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildLocator
        {
            Branch = new Dzaba.TeamCityClient.Locators.BranchLocator { SingleValue = "main" }
        };

        sut.ToString().Should().Be("branch:(main)");
    }
}
