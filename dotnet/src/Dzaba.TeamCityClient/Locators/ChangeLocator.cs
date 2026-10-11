namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering Change entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/changelocator.html
/// </summary>
public class ChangeLocator : Locator
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
    /// Build type locator.
    /// </summary>
    public BuildTypeLocator BuildType
    {
        get => Get<BuildTypeLocator>("buildType");
        set => this["buildType"] = value;
    }

    /// <summary>
    /// Change comment.
    /// </summary>
    public string Comment
    {
        get => Get<string>("comment");
        set => this["comment"] = value;
    }

    /// <summary>
    /// Name of a file modified by the change.
    /// </summary>
    public string File
    {
        get => Get<string>("file");
        set => this["file"] = value;
    }

    /// <summary>
    /// Change id.
    /// </summary>
    public long? Id
    {
        get => GetStruct<long>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// Commit SHA.
    /// </summary>
    public string InternalVersion
    {
        get => Get<string>("internalVersion");
        set => this["internalVersion"] = value;
    }

    /// <summary>
    /// Multiple locators, returns a union of the results.
    /// Formatted as <c>item:(locator1),item:(locator2)</c>.
    /// </summary>
    public IReadOnlyList<ChangeLocator> Items
    {
        get => Get<IReadOnlyList<ChangeLocator>>("item");
        set => this["item"] = value;
    }

    /// <summary>
    /// Filters by whether the change is pending.
    /// </summary>
    public bool? Pending
    {
        get => GetStruct<bool>("pending");
        set => this["pending"] = value;
    }

    /// <summary>
    /// Project locator.
    /// </summary>
    public ProjectLocator Project
    {
        get => Get<ProjectLocator>("project");
        set => this["project"] = value;
    }

    /// <summary>
    /// Commit SHA since which the changes should be returned.
    /// </summary>
    public string SinceChange
    {
        get => Get<string>("sinceChange");
        set => this["sinceChange"] = value;
    }

    /// <summary>
    /// User locator.
    /// </summary>
    public UserLocator User
    {
        get => Get<UserLocator>("user");
        set => this["user"] = value;
    }

    /// <summary>
    /// VCS side username.
    /// </summary>
    public string Username
    {
        get => Get<string>("username");
        set => this["username"] = value;
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

    /// <summary>
    /// Change version.
    /// </summary>
    public string Version
    {
        get => Get<string>("version");
        set => this["version"] = value;
    }
}
