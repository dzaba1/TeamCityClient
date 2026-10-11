using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class TagLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.TagLocator
        {
            Name = "release",
            Private = false,
            Owner = new Dzaba.TeamCityClient.Locators.UserLocator { SingleValue = "current" }
        };

        sut.ToString().Should().Be("name:release,private:false,owner:(current)");
    }

    [Test]
    public void ToString_WhenUsedInBuildLocator_ThenItIsFormattedAsNestedLocator()
    {
        var sut = new Dzaba.TeamCityClient.Locators.BuildLocator
        {
            Tag = new Dzaba.TeamCityClient.Locators.TagLocator { Name = "release" }
        };

        sut.ToString().Should().Be("tag:(name:release)");
    }
}
