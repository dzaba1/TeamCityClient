using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class AgentPoolLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AgentPoolLocator
        {
            Id = 2,
            Name = "Default",
            PageStart = 1,
            PageCount = 5
        };

        sut.ToString().Should().Be("id:2,name:Default,start:1,count:5");
    }

    [Test]
    public void ToString_WhenSingleValueIsSet_ThenItIsWrittenWithoutDimensionName()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AgentPoolLocator { SingleValue = 7 };

        sut.ToString().Should().Be("7");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AgentPoolLocator
        {
            Project = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            Agent = new Dzaba.TeamCityClient.Locators.AgentLocator { Name = "DefaultAgent" }
        };

        sut.ToString().Should().Be("project:(id:Proj),agent:(name:DefaultAgent)");
    }
}
