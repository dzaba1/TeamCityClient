using FluentAssertions;
using NUnit.Framework;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("int")]
        public int Int { get; set; }

        [JsonPropertyName("nullableInt")]
        public int? NullableInt { get; set; }

        [JsonPropertyName("string")]
        public string String { get; set; }

        [JsonPropertyName("enum")]
        public DayOfWeek Enum { get; set; }

        [JsonPropertyName("nullableEnum")]
        public DayOfWeek? NullableEnum { get; set; }
    }
}
