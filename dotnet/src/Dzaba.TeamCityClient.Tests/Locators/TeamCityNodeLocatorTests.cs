using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class TeamCityNodeLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.TeamCityNodeLocator
        {
            Id = "node-1",
            State = "online"
        };

        sut.ToString().Should().Be("id:node-1,state:online");
    }

    [TestCase(TeamCityNodeLocatorRole.MainNode, "role:main_node")]
    [TestCase(TeamCityNodeLocatorRole.SecondaryNode, "role:secondary_node")]
    public void ToString_WhenRoleIsSet_ThenItIsWrittenAsEnumMemberValue(TeamCityNodeLocatorRole role, string expected)
    {
        var sut = new Dzaba.TeamCityClient.Locators.TeamCityNodeLocator { Role = role };

        sut.ToString().Should().Be(expected);
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.TeamCityNodeLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.TeamCityNodeLocator { Id = "a" },
                new Dzaba.TeamCityClient.Locators.TeamCityNodeLocator { Role = TeamCityNodeLocatorRole.MainNode }
            ]
        };

        sut.ToString().Should().Be("item:(id:a),item:(role:main_node)");
    }
}
