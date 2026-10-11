using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class UserGroupLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.UserGroupLocator
        {
            Name = "GroupName",
            Key = "GroupKey"
        };

        sut.ToString().Should().Be("name:GroupName,key:GroupKey");
    }

    [Test]
    public void ToString_WhenLocatorHasItems_ThenItemsAreRepeated()
    {
        var sut = new Dzaba.TeamCityClient.Locators.UserGroupLocator
        {
            Items =
            [
                new Dzaba.TeamCityClient.Locators.UserGroupLocator { Name = "First" },
                new Dzaba.TeamCityClient.Locators.UserGroupLocator { Key = "SecondKey" }
            ]
        };

        sut.ToString().Should().Be("item:(name:First),item:(key:SecondKey)");
    }

    [Test]
    public void ToString_WhenUsedAsNestedLocatorWithItems_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.UserLocator
        {
            Group = new Dzaba.TeamCityClient.Locators.UserGroupLocator
            {
                Items = [new Dzaba.TeamCityClient.Locators.UserGroupLocator { Name = "A" }, new Dzaba.TeamCityClient.Locators.UserGroupLocator { Name = "B" }]
            }
        };

        sut.ToString().Should().Be("group:(item:(name:A),item:(name:B))");
    }
}
