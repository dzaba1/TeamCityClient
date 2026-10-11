namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering CloudProfile entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/cloudprofilelocator.html
/// </summary>
public class CloudProfileLocator : Locator
{
    /// <summary>
    /// Project locator, filters by projects where the profiles are accessible.
    /// </summary>
    public ProjectLocator AffectedProject
    {
        get => Get<ProjectLocator>("affectedProject");
        set => this["affectedProject"] = value;
    }

    /// <summary>
    /// Cloud provider id of the profile.
    /// </summary>
    public string CloudProviderId
    {
        get => Get<string>("cloudProviderId");
        set => this["cloudProviderId"] = value;
    }

    /// <summary>
    /// Profile id.
    /// </summary>
    public string Id
    {
        get => Get<string>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// Cloud image locator, filters by an image that belongs to the profile.
    /// </summary>
    public CloudImageLocator Image
    {
        get => Get<CloudImageLocator>("image");
        set => this["image"] = value;
    }

    /// <summary>
    /// Cloud instance locator, filters by an instance that belongs to the profile.
    /// </summary>
    public CloudInstanceLocator Instance
    {
        get => Get<CloudInstanceLocator>("instance");
        set => this["instance"] = value;
    }

    /// <summary>
    /// Profile name condition.
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }

    /// <summary>
    /// Project locator, filters by projects defining the profiles.
    /// </summary>
    public ProjectLocator Project
    {
        get => Get<ProjectLocator>("project");
        set => this["project"] = value;
    }

    /// <summary>
    /// Property matcher.
    /// </summary>
    public LocatorProperty<LocatorPropertyType> Property
    {
        get => Get<LocatorProperty<LocatorPropertyType>>("property");
        set => this["property"] = value;
    }
}
