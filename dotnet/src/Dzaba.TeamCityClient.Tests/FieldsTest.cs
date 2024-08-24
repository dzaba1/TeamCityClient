using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Dzaba.TeamCityClient.Tests;

[TestFixture]
public class FieldsTest
{
    [Test]
    public void GetSimpleFields_WhenCalled_ThenItMakesCorrectFieldsString()
    {
        var result = Fields.GetSimpleFields<MyModel>();

        result.Should().Be("int,nullableInt,string,enum,nullableEnum");
    }

    private class MyModel
    {
        [JsonProperty("int")]
        public int Int { get; set; }

        [JsonProperty("nullableInt")]
        public int? NullableInt { get; set; }

        [JsonProperty("string")]
        public string String { get; set; }

        [JsonProperty("enum")]
        public DayOfWeek Enum { get; set; }

        [JsonProperty("nullableEnum")]
        public DayOfWeek? NullableEnum { get; set; }
    }
}
