namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering Node entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/teamcitynodelocator.html
/// </summary>
public class TeamCityNodeLocator : Locator
{
    /// <summary>
    /// Node id. Used in the page examples, but not listed in its dimensions table.
    /// </summary>
    public string Id
    {
        get => Get<string>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// Multiple locators, returns a union of the results.
    /// Formatted as <c>item:(locator1),item:(locator2)</c>.
    /// </summary>
    public IReadOnlyList<TeamCityNodeLocator> Items
    {
        get => Get<IReadOnlyList<TeamCityNodeLocator>>("item");
        set => this["item"] = value;
    }

    /// <summary>
    /// Node role.
    /// </summary>
    public TeamCityNodeLocatorRole? Role
    {
        get => GetStruct<TeamCityNodeLocatorRole>("role");
        set => this["role"] = value;
    }

    /// <summary>
    /// Node state.
    /// </summary>
    public string State
    {
        get => Get<string>("state");
        set => this["state"] = value;
    }
}
