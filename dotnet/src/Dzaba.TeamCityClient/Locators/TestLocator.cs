namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering Test entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/testlocator.html
/// </summary>
public class TestLocator : Locator
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
    /// Build locator, finds tests under the build. Used in the page examples, but not listed in its dimensions table.
    /// </summary>
    public BuildLocator Build
    {
        get => Get<BuildLocator>("build");
        set => this["build"] = value;
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
    /// Test id.
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
    public IReadOnlyList<TestLocator> Items
    {
        get => Get<IReadOnlyList<TestLocator>>("item");
        set => this["item"] = value;
    }

    /// <summary>
    /// Limits processing to the latest N tests.
    /// </summary>
    public int? LookupLimit
    {
        get => GetStruct<int>("lookupLimit");
        set => this["lookupLimit"] = value;
    }

    /// <summary>
    /// Build type locator, used to find out whether the test is affected by mutes in the build type.
    /// </summary>
    public BuildTypeLocator MuteAffected
    {
        get => Get<BuildTypeLocator>("muteAffected");
        set => this["muteAffected"] = value;
    }

    /// <summary>
    /// Test name.
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }
}
