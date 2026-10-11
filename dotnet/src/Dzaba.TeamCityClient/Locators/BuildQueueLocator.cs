namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering queued Build entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/buildqueuelocator.html
/// </summary>
public class BuildQueueLocator : Locator
{
    /// <summary>
    /// Agent locator.
    /// </summary>
    public AgentLocator Agent
    {
        get => Get<AgentLocator>("agent");
        set => this["agent"] = value;
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
    /// Queued build id.
    /// </summary>
    public long? Id
    {
        get => GetStruct<long>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// Multiple locators, returns a union of the results.
    /// Formatted as <c>item:(locator1),item:(locator2)</c>.
    /// </summary>
    public IReadOnlyList<BuildQueueLocator> Items
    {
        get => Get<IReadOnlyList<BuildQueueLocator>>("item");
        set => this["item"] = value;
    }

    /// <summary>
    /// Filters by whether the build is personal.
    /// </summary>
    public bool? Personal
    {
        get => GetStruct<bool>("personal");
        set => this["personal"] = value;
    }

    /// <summary>
    /// Agent pool locator.
    /// </summary>
    public AgentPoolLocator Pool
    {
        get => Get<AgentPoolLocator>("pool");
        set => this["pool"] = value;
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
    /// User locator, filters by the user who started the build.
    /// </summary>
    public UserLocator User
    {
        get => Get<UserLocator>("user");
        set => this["user"] = value;
    }
}
