namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering Project entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/projectlocator.html
/// </summary>
public class ProjectLocator : Locator
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
    /// Filters by whether the project is archived.
    /// </summary>
    public bool? Archived
    {
        get => GetStruct<bool>("archived");
        set => this["archived"] = value;
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
    /// Build type locator.
    /// </summary>
    public BuildTypeLocator BuildType
    {
        get => Get<BuildTypeLocator>("buildType");
        set => this["buildType"] = value;
    }

    /// <summary>
    /// Default template locator.
    /// </summary>
    public BuildTypeLocator DefaultTemplate
    {
        get => Get<BuildTypeLocator>("defaultTemplate");
        set => this["defaultTemplate"] = value;
    }

    /// <summary>
    /// Project internal id.
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
    public IReadOnlyList<ProjectLocator> Items
    {
        get => Get<IReadOnlyList<ProjectLocator>>("item");
        set => this["item"] = value;
    }

    /// <summary>
    /// Project name.
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }

    /// <summary>
    /// Associated agent pool locator.
    /// </summary>
    public AgentPoolLocator Pool
    {
        get => Get<AgentPoolLocator>("pool");
        set => this["pool"] = value;
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
    /// Project feature locator.
    /// </summary>
    public ProjectLocator ProjectFeature
    {
        get => Get<ProjectLocator>("projectFeature");
        set => this["projectFeature"] = value;
    }

    /// <summary>
    /// Project UUID.
    /// </summary>
    public string Uuid
    {
        get => Get<string>("uuid");
        set => this["uuid"] = value;
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
    /// Filters by whether the project is virtual (default: <c>false</c>).
    /// </summary>
    public bool? Virtual
    {
        get => GetStruct<bool>("virtual");
        set => this["virtual"] = value;
    }
}
