using Dzaba.TeamCityClient.Model;
using FluentAssertions;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests;

[TestFixture]
public class TeamCityPageExpanderTests
{
    [Test]
    public async Task GetAllAsync_WhenLocatorProvided_ThenItIsUsedForPaging()
    {
        var locator = new Locator();
        var callCount = 0;

        var result = await TeamCityPageExpander.GetAllAsync(l =>
        {
            callCount++;
            if (callCount == 1)
            {
                return Enumerable.Range(0, l.Count.Value).ToAsyncEnumerable();
            }
            if (callCount == 2)
            {
                return Enumerable.Range(0, 10).ToAsyncEnumerable();
            }
            return (new int[0]).ToAsyncEnumerable();
        }, locator, 50).ToArrayAsync();

        result.Should().HaveCount(60);
        callCount.Should().Be(2);
    }
}
