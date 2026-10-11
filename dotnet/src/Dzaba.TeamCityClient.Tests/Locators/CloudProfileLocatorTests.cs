using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class CloudProfileLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.CloudProfileLocator
        {
            Id = "profile-1",
            Name = "MyCloudProfile",
            CloudProviderId = "amazon",
            Property = new Dzaba.TeamCityClient.Locators.LocatorProperty<LocatorPropertyType>("region", "eu", LocatorPropertyType.Contains),
            PageStart = 1,
            PageCount = 2
        };

        sut.ToString().Should().Be("id:profile-1,name:MyCloudProfile,cloudProviderId:amazon,property:(name:region,value:eu,matchType:contains),start:1,count:2");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.CloudProfileLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Root" },
            Project = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            Image = new Dzaba.TeamCityClient.Locators.CloudImageLocator { Name = "Img" },
            Instance = new Dzaba.TeamCityClient.Locators.CloudInstanceLocator { Id = "i1" }
        };

        sut.ToString().Should().Be("affectedProject:(id:Root),project:(id:Proj),image:(name:Img),instance:(id:i1)");
    }
}
