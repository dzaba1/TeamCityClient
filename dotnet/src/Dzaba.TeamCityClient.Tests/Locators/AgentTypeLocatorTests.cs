using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class AgentTypeLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AgentTypeLocator
        {
            Id = 12,
            PageStart = 5,
            PageCount = 10
        };

        sut.ToString().Should().Be("id:12,start:5,count:10");
    }

    [Test]
    public void ToString_WhenSingleValueIsSet_ThenItIsWrittenWithoutDimensionName()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AgentTypeLocator { SingleValue = "typeId" };

        sut.ToString().Should().Be("typeId");
    }

    [Test]
    public void ToString_WhenAgentIsSet_ThenItIsFormattedAsNestedLocator()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AgentTypeLocator
        {
            Agent = new Dzaba.TeamCityClient.Locators.AgentLocator { Name = "agent1" }
        };

        sut.ToString().Should().Be("agent:(name:agent1)");
    }
}
