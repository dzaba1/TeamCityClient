using System.Runtime.Serialization;

namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Value of a locator dimension that supports <c>true</c>, <c>false</c> and <c>any</c>.
/// </summary>
public enum LocatorTriState
{
    /// <summary>
    /// Matches entities for which the condition is true.
    /// </summary>
    [EnumMember(Value = "true")]
    True,

    /// <summary>
    /// Matches entities for which the condition is false.
    /// </summary>
    [EnumMember(Value = "false")]
    False,

    /// <summary>
    /// Matches entities regardless of the condition.
    /// </summary>
    [EnumMember(Value = "any")]
    Any
}
