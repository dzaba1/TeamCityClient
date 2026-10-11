namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering Build entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/buildlocator.html
/// </summary>
public class BuildLocator : Locator
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
    /// Agent locator, filters by the agent that executed the build.
    /// </summary>
    public AgentLocator Agent
    {
        get => Get<AgentLocator>("agent");
        set => this["agent"] = value;
    }

    /// <summary>
    /// Filters by the agent type id of the agent used to execute the build.
    /// </summary>
    public int? AgentTypeId
    {
        get => GetStruct<int>("agentTypeId");
        set => this["agentTypeId"] = value;
    }

    /// <summary>
    /// Matches builds in any state.
    /// </summary>
    public bool? Any
    {
        get => GetStruct<bool>("any");
        set => this["any"] = value;
    }

    /// <summary>
    /// Artifact dependency locator.
    /// </summary>
    public BuildDependencyLocator ArtifactDependency
    {
        get => Get<BuildDependencyLocator>("artifactDependency");
        set => this["artifactDependency"] = value;
    }

    /// <summary>
    /// Branch locator, filters by branch.
    /// </summary>
    public BranchLocator Branch
    {
        get => Get<BranchLocator>("branch");
        set => this["branch"] = value;
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
    /// Filters by whether the build was canceled.
    /// </summary>
    public bool? Canceled
    {
        get => GetStruct<bool>("canceled");
        set => this["canceled"] = value;
    }

    /// <summary>
    /// Agent locator, filters by agents that can run the build.
    /// </summary>
    public AgentLocator CompatibleAgent
    {
        get => Get<AgentLocator>("compatibleAgent");
        set => this["compatibleAgent"] = value;
    }

    /// <summary>
    /// Filters by whether the build is composite.
    /// </summary>
    public bool? Composite
    {
        get => GetStruct<bool>("composite");
        set => this["composite"] = value;
    }

    /// <summary>
    /// When <c>true</c>, returns only normal builds: finished, not canceled, not failed to start,
    /// not personal, and on the default branch for branched configurations.
    /// </summary>
    public bool? DefaultFilter
    {
        get => GetStruct<bool>("defaultFilter");
        set => this["defaultFilter"] = value;
    }

    /// <summary>
    /// Filters by whether the build failed to start.
    /// </summary>
    public bool? FailedToStart
    {
        get => GetStruct<bool>("failedToStart");
        set => this["failedToStart"] = value;
    }

    /// <summary>
    /// Filters by finish date.
    /// </summary>
    public BuildDateLocator FinishDate
    {
        get => Get<BuildDateLocator>("finishDate");
        set => this["finishDate"] = value;
    }

    /// <summary>
    /// Filters by whether the build has finished.
    /// </summary>
    public bool? Finished
    {
        get => GetStruct<bool>("finished");
        set => this["finished"] = value;
    }

    /// <summary>
    /// Filters by whether the build is hanging.
    /// </summary>
    public bool? Hanging
    {
        get => GetStruct<bool>("hanging");
        set => this["hanging"] = value;
    }

    /// <summary>
    /// Filters by whether the build is a history build.
    /// </summary>
    public bool? History
    {
        get => GetStruct<bool>("history");
        set => this["history"] = value;
    }

    /// <summary>
    /// Build id.
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
    public IReadOnlyList<BuildLocator> Items
    {
        get => Get<IReadOnlyList<BuildLocator>>("item");
        set => this["item"] = value;
    }

    /// <summary>
    /// Limits processing to the latest N builds.
    /// </summary>
    public int? LookupLimit
    {
        get => GetStruct<int>("lookupLimit");
        set => this["lookupLimit"] = value;
    }

    /// <summary>
    /// Build number.
    /// </summary>
    public string Number
    {
        get => Get<string>("number");
        set => this["number"] = value;
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
    /// Filters by whether the build is pinned.
    /// </summary>
    public bool? Pinned
    {
        get => GetStruct<bool>("pinned");
        set => this["pinned"] = value;
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
    public LocatorProperty<BuildLocatorProperty> Property
    {
        get => Get<LocatorProperty<BuildLocatorProperty>>("property");
        set => this["property"] = value;
    }

    /// <summary>
    /// Filters by whether the build is queued.
    /// </summary>
    public bool? Queued
    {
        get => GetStruct<bool>("queued");
        set => this["queued"] = value;
    }

    /// <summary>
    /// Filters by queue date.
    /// </summary>
    public BuildDateLocator QueuedDate
    {
        get => Get<BuildDateLocator>("queuedDate");
        set => this["queuedDate"] = value;
    }

    /// <summary>
    /// Filters by build revision.
    /// </summary>
    public string Revision
    {
        get => Get<string>("revision");
        set => this["revision"] = value;
    }

    /// <summary>
    /// Filters by whether the build is running.
    /// </summary>
    public bool? Running
    {
        get => GetStruct<bool>("running");
        set => this["running"] = value;
    }

    /// <summary>
    /// Snapshot dependency locator.
    /// </summary>
    public BuildDependencyLocator SnapshotDependency
    {
        get => Get<BuildDependencyLocator>("snapshotDependency");
        set => this["snapshotDependency"] = value;
    }

    /// <summary>
    /// Filters by start date.
    /// </summary>
    public BuildDateLocator StartDate
    {
        get => Get<BuildDateLocator>("startDate");
        set => this["startDate"] = value;
    }

    /// <summary>
    /// Filters by state.
    /// </summary>
    public BuildLocatorState? State
    {
        get => GetStruct<BuildLocatorState>("state");
        set => this["state"] = value;
    }

    /// <summary>
    /// Filters by status text.
    /// </summary>
    public string Status
    {
        get => Get<string>("status");
        set => this["status"] = value;
    }

    /// <summary>
    /// Tag locator, filters by tag.
    /// </summary>
    public TagLocator Tag
    {
        get => Get<TagLocator>("tag");
        set => this["tag"] = value;
    }

    /// <summary>
    /// Filters by id of a build or build promotion.
    /// </summary>
    public int? TaskId
    {
        get => GetStruct<int>("taskId");
        set => this["taskId"] = value;
    }

    /// <summary>
    /// User locator. For personal builds matches the build owner, for other builds matches the triggering user.
    /// </summary>
    public UserLocator User
    {
        get => Get<UserLocator>("user");
        set => this["user"] = value;
    }
}
