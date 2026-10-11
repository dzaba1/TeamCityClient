using System.Runtime.Serialization;

namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Node role used by the <c>role</c> dimension of <see cref="TeamCityNodeLocator"/>.
/// </summary>
public enum TeamCityNodeLocatorRole
{
    /// <summary>
    /// The main node.
    /// </summary>
    [EnumMember(Value = "main_node")]
    MainNode,

    /// <summary>
    /// A secondary node.
    /// </summary>
    [EnumMember(Value = "secondary_node")]
    SecondaryNode
}
