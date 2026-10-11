using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class CloudImageLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.CloudImageLocator
        {
            Id = "image-1",
            Name = "MyImage",
            Property = new Dzaba.TeamCityClient.Locators.LocatorProperty<LocatorPropertyType>("os", "linux", LocatorPropertyType.Equals),
            PageStart = 1,
            PageCount = 2
        };

        sut.ToString().Should().Be("id:image-1,name:MyImage,property:(name:os,value:linux,matchType:equals),start:1,count:2");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.CloudImageLocator
        {
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Root" },
            Project = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            Agent = new Dzaba.TeamCityClient.Locators.AgentLocator { Name = "A1" },
            AgentPool = new Dzaba.TeamCityClient.Locators.AgentPoolLocator { Id = 2 },
            AgentType = new Dzaba.TeamCityClient.Locators.AgentTypeLocator { Id = 3 },
            CompatibleBuildPromotion = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 5 },
            CompatibleBuildType = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Bt1" },
            Instance = new Dzaba.TeamCityClient.Locators.CloudInstanceLocator { Id = "i1" },
            Profile = new Dzaba.TeamCityClient.Locators.CloudProfileLocator { Name = "P" }
        };

        sut.ToString().Should().Be("affectedProject:(id:Root),project:(id:Proj),agent:(name:A1),agentPool:(id:2),agentType:(id:3),compatibleBuildPromotion:(id:5),compatibleBuildType:(id:Bt1),instance:(id:i1),profile:(name:P)");
    }
}
