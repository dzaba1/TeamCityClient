namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering VcsRoot entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/vcsrootlocator.html
/// </summary>
public class VcsRootLocator : Locator
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
    /// VCS root id.
    /// </summary>
    public string Id
    {
        get => Get<string>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// VCS root internal id.
    /// </summary>
    public int? InternalId
    {
        get => GetStruct<int>("internalId");
        set => this["internalId"] = value;
    }

    /// <summary>
    /// Multiple locators, returns a union of the results.
    /// Formatted as <c>item:(locator1),item:(locator2)</c>.
    /// </summary>
    public IReadOnlyList<VcsRootLocator> Items
    {
        get => Get<IReadOnlyList<VcsRootLocator>>("item");
        set => this["item"] = value;
    }

    /// <summary>
    /// Limits processing to the latest N VCS roots.
    /// </summary>
    public int? LookupLimit
    {
        get => GetStruct<int>("lookupLimit");
        set => this["lookupLimit"] = value;
    }

    /// <summary>
    /// VCS root name.
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
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
    public LocatorProperty<VcsRootLocatorProperty> Property
    {
        get => Get<LocatorProperty<VcsRootLocatorProperty>>("property");
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
    /// VCS root UUID.
    /// </summary>
    public string Uuid
    {
        get => Get<string>("uuid");
        set => this["uuid"] = value;
    }
}
