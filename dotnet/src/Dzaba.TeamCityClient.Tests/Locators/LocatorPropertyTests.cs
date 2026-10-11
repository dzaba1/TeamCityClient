using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class LocatorPropertyTests
{
    [Test]
    public void ToString_WhenMatchTypeIsEquals_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.LocatorProperty<LocatorPropertyType>("env.OS", "Linux", LocatorPropertyType.Equals);

        sut.ToString().Should().Be("(name:env.OS,value:Linux,matchType:equals)");
    }

    [Test]
    public void ToString_WhenAnyMatchType_ThenItHasEnumMemberValue(
        [Values] LocatorPropertyType matchType)
    {
        var sut = new Dzaba.TeamCityClient.Locators.LocatorProperty<LocatorPropertyType>("n", "v", matchType);

        var act = () => sut.ToString();

        act.Should().NotThrow();
    }
}
