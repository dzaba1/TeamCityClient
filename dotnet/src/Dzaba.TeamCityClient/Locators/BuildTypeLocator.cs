namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering BuildType entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/buildtypelocator.html
/// </summary>
public class BuildTypeLocator : Locator
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
    /// Build type internal id.
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
    public IReadOnlyList<BuildTypeLocator> Items
    {
        get => Get<IReadOnlyList<BuildTypeLocator>>("item");
        set => this["item"] = value;
    }

    /// <summary>
    /// Build type name.
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }

    /// <summary>
    /// Filters by whether the build configuration is paused.
    /// </summary>
    public bool? Paused
    {
        get => GetStruct<bool>("paused");
        set => this["paused"] = value;
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
    /// Build type locator of the base template.
    /// </summary>
    public BuildTypeLocator Template
    {
        get => Get<BuildTypeLocator>("template");
        set => this["template"] = value;
    }

    /// <summary>
    /// Filters by whether the build configuration is a template.
    /// </summary>
    public bool? TemplateFlag
    {
        get => GetStruct<bool>("templateFlag");
        set => this["templateFlag"] = value;
    }

    /// <summary>
    /// Build type UUID.
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
    /// VCS root instance locator.
    /// </summary>
    public VcsRootInstanceLocator VcsRootInstance
    {
        get => Get<VcsRootInstanceLocator>("vcsRootInstance");
        set => this["vcsRootInstance"] = value;
    }
}
