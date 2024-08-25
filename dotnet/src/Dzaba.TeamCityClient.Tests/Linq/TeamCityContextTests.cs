using AutoFixture;
using Dzaba.TeamCityClient.Linq;
using Dzaba.TeamCityClient.Model;
using Dzaba.TestUtils;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests.Linq;

[TestFixture]
public class TeamCityContextTests
{
    private IFixture fixture;

    [SetUp]
    public void Setup()
    {
        fixture = TestFixture.Create();
    }

    private TeamCityContext CreateSut()
    {
        return fixture.Create<TeamCityContext>();
    }

    private Mock<ITeamCityClient> SetupClient()
    {
        return fixture.Freeze<Mock<ITeamCityClient>>();
    }

    private Build GetBuild(long id, string status = BuildStatuses.Success)
    {
        return new Build
        {
            Id = id,
            Status = status,
        };
    }

    [Test]
    public void Builds_WhenToArray_ThenAllBuilds()
    {
        var client = SetupClient();
        client.Setup(x => x.GetAllBuildsAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(new Builds
            {
                Count = 10,
                Build = Enumerable.Range(0, 10).Select(i => GetBuild(i)).ToArray()
            });

        var sut = CreateSut();

        var result = sut.Builds
            .ToArray();

        result.Should().HaveCount(10);
    }

    [Test]
    public void Builds_WhenSimpleSelect_ThenProperties()
    {
        var client = SetupClient();
        client.Setup(x => x.GetAllBuildsAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(new Builds
            {
                Count = 0,
                Build = []
            });

        var sut = CreateSut();

        var result = sut.Builds
            .Select(b => new { b.Id, b.Status })
            .ToArray();

        result.Should().HaveCount(10);
    }
}
