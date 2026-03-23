using System.Reflection;
using System.Runtime.Serialization;

namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Locator property for filtering entities by their properties. It supports various match types, such as existence, equality, string matching, and version comparison.
/// </summary>
public class LocatorProperty
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="matchType"></param>
    public LocatorProperty(string name, string value, LocatorPropertyType matchType)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
        Value = value;
        MatchType = matchType;
    }

    /// <summary>
    /// Property name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Property value
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Match type
    /// </summary>
    public LocatorPropertyType MatchType { get; }

    /// <inheritdoc />
    public override string ToString()
    {
        var memberInfo = MatchType.GetType().GetMember(MatchType.ToString()).First();
        var matchTypeStr = memberInfo.GetCustomAttribute<EnumMemberAttribute>().Value;
        return $"(name:{Name},value:{Value},matchType:{matchTypeStr})";
    }
}
