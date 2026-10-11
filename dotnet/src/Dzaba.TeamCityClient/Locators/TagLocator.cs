namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering Tag entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/taglocator.html
/// </summary>
public class TagLocator : Locator
{
    /// <summary>
    /// Tag name.
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }

    /// <summary>
    /// User locator, filters by the owner of the tag.
    /// </summary>
    public UserLocator Owner
    {
        get => Get<UserLocator>("owner");
        set => this["owner"] = value;
    }

    /// <summary>
    /// Filters by whether the tag is private.
    /// </summary>
    public bool? Private
    {
        get => GetStruct<bool>("private");
        set => this["private"] = value;
    }
}
