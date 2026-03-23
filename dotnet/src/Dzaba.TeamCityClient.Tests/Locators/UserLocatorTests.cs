using Dzaba.TeamCityClient.Locators;
using Dzaba.TestUtils;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class UserLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.UserLocator();
        sut.AffectedGroup = new Dzaba.TeamCityClient.Locators.UserGroupLocator
        {
            Name = "AffectedGroupName",
            Key = "AffectedGroupKey"
        };
        sut.Email = "test@test.com";
        sut.Group = new Dzaba.TeamCityClient.Locators.UserGroupLocator
        {
            Name = "GroupName",
            Key = "GroupKey"
        };
        sut.LastLogin = new DateTimeOffset(2024, 6, 1, 12, 0, 0, TimeSpan.Zero);
        sut.Property = new LocatorProperty(nameof(Dzaba.TeamCityClient.Locators.UserLocator.Email), "test", LocatorPropertyType.Contains);
        sut.Role = "Reader";

        var result = sut.ToString();
        result.Should().Be("affectedGroup:(name:AffectedGroupName,key:AffectedGroupKey),email:test@test.com,group:(name:GroupName,key:GroupKey),lastLogin:01.06.2024 12:00:00 +00:00,property:(name:Email,value:test,matchType:contains),role:Reader");
    }
}
