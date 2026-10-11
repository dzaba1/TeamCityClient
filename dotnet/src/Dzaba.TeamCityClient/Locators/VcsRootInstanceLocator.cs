namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering VcsRootInstance entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/vcsrootinstancelocator.html
/// </summary>
public class VcsRootInstanceLocator : Locator
{
    /// <summary>
    /// Project locator, filters by project including direct or indirect parent projects.
    /// </summary>
    public ProjectLocator AffectedProject
    {
        get => Get<ProjectLocator>("affectedProject");
        set => this["affectedProject"] = value;
    }

    /// <summary>
    /// Build locator.
    /// </summary>
    public BuildLocator Build
    {
        get => Get<BuildLocator>("build");
        set => this["build"] = value;
    }

    /// <summary>
    /// Build type locator, filters by build configuration.
    /// </summary>
    public BuildTypeLocator BuildType
    {
        get => Get<BuildTypeLocator>("buildType");
        set => this["buildType"] = value;
    }

    /// <summary>
    /// VCS root instance id.
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
    public IReadOnlyList<VcsRootInstanceLocator> Items
    {
        get => Get<IReadOnlyList<VcsRootInstanceLocator>>("item");
        set => this["item"] = value;
    }

    /// <summary>
    /// Limits processing to the latest N VCS root instances.
    /// </summary>
    public int? LookupLimit
    {
        get => GetStruct<int>("lookupLimit");
        set => this["lookupLimit"] = value;
    }

    /// <summary>
    /// Project locator, filters by direct parent project.
    /// </summary>
    public ProjectLocator Project
    {
        get => Get<ProjectLocator>("project");
        set => this["project"] = value;
    }

    /// <summary>
    /// Property matcher.
    /// </summary>
    public LocatorProperty<VcsRootInstanceLocatorProperty> Property
    {
        get => Get<LocatorProperty<VcsRootInstanceLocatorProperty>>("property");
        set => this["property"] = value;
    }

    /// <summary>
    /// Type of VCS, e.g. <c>jetbrains.git</c>.
    /// </summary>
    public string Type
    {
        get => Get<string>("type");
        set => this["type"] = value;
    }

    /// <summary>
    /// VCS root locator.
    /// </summary>
    public VcsRootLocator VcsRoot
    {
        get => Get<VcsRootLocator>("vcsRoot");
        set => this["vcsRoot"] = value;
    }

    /// <summary>
    /// Filters by whether the VCS root is used for versioned settings.
    /// </summary>
    public bool? VersionedSettings
    {
        get => GetStruct<bool>("versionedSettings");
        set => this["versionedSettings"] = value;
    }
}
