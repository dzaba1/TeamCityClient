using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dzaba.TeamCityClient;

/// <summary>
/// Converts TeamCity string datetime representation to or from <see cref="DateTimeOffset"/>
/// </summary>
public sealed class TeamCityDateTimeConverter : JsonConverter<DateTimeOffset>
{
    /// <summary>
    /// Converts TeamCity string into <see cref="DateTimeOffset"/>.
    /// </summary>
    /// <param name="value">String value</param>
    /// <returns><see cref="DateTimeOffset"/></returns>
    public static DateTimeOffset FromString(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));

        return DateTimeOffset.ParseExact(value, "yyyyMMdd'T'HHmmsszz'00'", CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Converts <see cref="DateTimeOffset"/> into TeamCity string.
    /// </summary>
    /// <param name="value"><see cref="DateTimeOffset"/> value.</param>
    /// <returns><see cref="string"/></returns>
    public static string ToString(DateTimeOffset value)
    {
        return value.ToString("yyyyMMdd'T'HHmmsszz'00'");
    }

    /// <inheritdoc />
    public override DateTimeOffset Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
        return FromString(reader.GetString());
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(ToString(value));
    }
}
