using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class AgentLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AgentLocator
        {
            Id = 3,
            Name = "DefaultAgent",
            Ip = "10.0.0.1",
            Authorized = LocatorTriState.True,
            Connected = LocatorTriState.Any,
            Enabled = LocatorTriState.False,
            PageStart = 5,
            PageCount = 10
        };

        sut.ToString().Should().Be("id:3,name:DefaultAgent,ip:10.0.0.1,authorized:true,connected:any,enabled:false,start:5,count:10");
    }

    [Test]
    public void ToString_WhenSingleValueIsSet_ThenItIsWrittenWithoutDimensionName()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AgentLocator { SingleValue = "DefaultAgent" };

        sut.ToString().Should().Be("DefaultAgent");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AgentLocator
        {
            Pool = new Dzaba.TeamCityClient.Locators.AgentPoolLocator { Id = 1 },
            Build = new Dzaba.TeamCityClient.Locators.BuildLocator { Id = 99 },
            Compatible = new Dzaba.TeamCityClient.Locators.AgentCompatibleLocator
            {
                BuildType = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Bt" }
            },
            Connected = LocatorTriState.True
        };

        sut.ToString().Should().Be("pool:(id:1),build:(id:99),compatible:(buildType:(id:Bt)),connected:true");
    }

    [Test]
    public void ToString_WhenParameterIsSet_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AgentLocator
        {
            Parameter = new Dzaba.TeamCityClient.Locators.LocatorProperty<LocatorPropertyType>("env.OS", "Linux", LocatorPropertyType.Contains)
        };

        sut.ToString().Should().Be("parameter:(name:env.OS,value:Linux,matchType:contains)");
    }
}
