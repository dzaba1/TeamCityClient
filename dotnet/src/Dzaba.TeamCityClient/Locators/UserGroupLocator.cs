namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering Group entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/usergrouplocator.html
/// </summary>
public class UserGroupLocator : Locator
{
    /// <summary>
    /// Multiple locators, returns a union of the results.
    /// Formatted as <c>item:(locator1),item:(locator2)</c>.
    /// </summary>
    public IReadOnlyList<UserGroupLocator> Items
    {
        get => Get<IReadOnlyList<UserGroupLocator>>("item");
        set => this["item"] = value;
    }

    /// <summary>
    /// User group key
    /// </summary>
    public string Key
    {
        get => Get<string>("key");
        set => this["key"] = value;
    }

    /// <summary>
    /// User group name
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }
}
