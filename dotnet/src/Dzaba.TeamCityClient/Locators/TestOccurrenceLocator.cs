namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering TestOccurrence entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/testoccurrencelocator.html
/// </summary>
public class TestOccurrenceLocator : Locator
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
    /// Branch locator.
    /// </summary>
    public BranchLocator Branch
    {
        get => Get<BranchLocator>("branch");
        set => this["branch"] = value;
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
    /// Filters by whether the test is currently failing.
    /// </summary>
    public bool? CurrentlyFailing
    {
        get => GetStruct<bool>("currentlyFailing");
        set => this["currentlyFailing"] = value;
    }

    /// <summary>
    /// Filters by whether the test is currently investigated.
    /// </summary>
    public bool? CurrentlyInvestigated
    {
        get => GetStruct<bool>("currentlyInvestigated");
        set => this["currentlyInvestigated"] = value;
    }

    /// <summary>
    /// Filters by whether the test is currently muted.
    /// </summary>
    public bool? CurrentlyMuted
    {
        get => GetStruct<bool>("currentlyMuted");
        set => this["currentlyMuted"] = value;
    }

    /// <summary>
    /// Test occurrence id.
    /// </summary>
    public string Id
    {
        get => Get<string>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// Filters by whether the test is ignored.
    /// </summary>
    public bool? Ignored
    {
        get => GetStruct<bool>("ignored");
        set => this["ignored"] = value;
    }

    /// <summary>
    /// Whether to include occurrences from personal builds.
    /// </summary>
    public bool? IncludePersonal
    {
        get => GetStruct<bool>("includePersonal");
        set => this["includePersonal"] = value;
    }

    /// <summary>
    /// Multiple locators, returns a union of the results.
    /// Formatted as <c>item:(locator1),item:(locator2)</c>.
    /// </summary>
    public IReadOnlyList<TestOccurrenceLocator> Items
    {
        get => Get<IReadOnlyList<TestOccurrenceLocator>>("item");
        set => this["item"] = value;
    }

    /// <summary>
    /// Limits processing to the latest N test occurrences.
    /// </summary>
    public int? LookupLimit
    {
        get => GetStruct<int>("lookupLimit");
        set => this["lookupLimit"] = value;
    }

    /// <summary>
    /// Filters by whether the test is muted.
    /// </summary>
    public bool? Muted
    {
        get => GetStruct<bool>("muted");
        set => this["muted"] = value;
    }

    /// <summary>
    /// Test name.
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }

    /// <summary>
    /// Filters by whether the occurrence is a new failure.
    /// </summary>
    public bool? NewFailure
    {
        get => GetStruct<bool>("newFailure");
        set => this["newFailure"] = value;
    }

    /// <summary>
    /// Test occurrence status.
    /// </summary>
    public TestOccurrenceLocatorStatus? Status
    {
        get => GetStruct<TestOccurrenceLocatorStatus>("status");
        set => this["status"] = value;
    }

    /// <summary>
    /// Test locator.
    /// </summary>
    public TestLocator Test
    {
        get => Get<TestLocator>("test");
        set => this["test"] = value;
    }
}
