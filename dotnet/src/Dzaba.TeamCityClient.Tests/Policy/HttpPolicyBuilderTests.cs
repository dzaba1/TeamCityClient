using AutoFixture;
using Dzaba.TeamCityClient.Policy;
using Dzaba.TestUtils;
using FluentAssertions;
using NUnit.Framework;
using Polly.Retry;

namespace Dzaba.TeamCityClient.Tests.Policy;

[TestFixture]
public class HttpPolicyBuilderTests
{
    private IFixture fixture;

    [SetUp]
    public void Setup()
    {
        fixture = TestFixture.Create();
    }

    private HttpPolicyBuilder CreateSut()
    {
        return fixture.Create<HttpPolicyBuilder>();
    }

    [Test]
    public void Build_WhenSettingsNull_ThenPolicyNull()
    {
        var sut = CreateSut();

        var result = sut.Build(null, null);
        result.Should().BeNull();
    }

    [Test]
    public void Build_WhenPolicySettings_ThenPolicy()
    {
        var sut = CreateSut();

        var result = sut.Build(new PolicySettings
        {
            RetryCount = 2,
            RetryWait = TimeSpan.FromSeconds(5)
        }, "url");

        result.Should().NotBeNull();
        result.Should().BeOfType<AsyncRetryPolicy<HttpResponseMessage>>();
    }
}
