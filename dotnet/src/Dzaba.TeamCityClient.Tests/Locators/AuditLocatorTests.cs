using Dzaba.TeamCityClient.Locators;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Locators;

[TestFixture]
public class AuditLocatorTests
{
    [Test]
    public void ToString_WhenLocatorHasProperties_ThenItIsFormattedCorrectly()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AuditLocator
        {
            Id = 15,
            Action = AuditLocatorAction.Build_type_template_edit_settings,
            SystemAction = LocatorTriState.False,
            PageStart = 2,
            PageCount = 1000
        };

        sut.ToString().Should().Be("id:15,action:build_type_template_edit_settings,systemAction:false,start:2,count:1000");
    }

    [Test]
    public void ToString_WhenSingleValueIsSet_ThenItIsWrittenWithoutDimensionName()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AuditLocator { SingleValue = 42 };

        sut.ToString().Should().Be("42");
    }

    [Test]
    public void ToString_WhenNestedLocatorsAreSet_ThenTheyAreWrappedInParentheses()
    {
        var sut = new Dzaba.TeamCityClient.Locators.AuditLocator
        {
            User = new Dzaba.TeamCityClient.Locators.UserLocator { SingleValue = "current" },
            AffectedProject = new Dzaba.TeamCityClient.Locators.ProjectLocator { Id = "Proj" },
            BuildType = new Dzaba.TeamCityClient.Locators.BuildTypeLocator { Id = "Bt1" }
        };

        sut.ToString().Should().Be("user:(current),affectedProject:(id:Proj),buildType:(id:Bt1)");
    }
}
