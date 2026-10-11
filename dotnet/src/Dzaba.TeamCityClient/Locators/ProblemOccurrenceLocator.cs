namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering ProblemOccurrence entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/problemoccurrencelocator.html
/// </summary>
public class ProblemOccurrenceLocator : Locator
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
    /// Filters by whether the problem is currently failing.
    /// </summary>
    public bool? CurrentlyFailing
    {
        get => GetStruct<bool>("currentlyFailing");
        set => this["currentlyFailing"] = value;
    }

    /// <summary>
    /// Filters by whether the problem is currently investigated.
    /// </summary>
    public bool? CurrentlyInvestigated
    {
        get => GetStruct<bool>("currentlyInvestigated");
        set => this["currentlyInvestigated"] = value;
    }

    /// <summary>
    /// Filters by whether the problem is currently muted.
    /// </summary>
    public bool? CurrentlyMuted
    {
        get => GetStruct<bool>("currentlyMuted");
        set => this["currentlyMuted"] = value;
    }

    /// <summary>
    /// Problem identity.
    /// </summary>
    public string Identity
    {
        get => Get<string>("identity");
        set => this["identity"] = value;
    }

    /// <summary>
    /// Multiple locators, returns a union of the results.
    /// Formatted as <c>item:(locator1),item:(locator2)</c>.
    /// </summary>
    public IReadOnlyList<ProblemOccurrenceLocator> Items
    {
        get => Get<IReadOnlyList<ProblemOccurrenceLocator>>("item");
        set => this["item"] = value;
    }

    /// <summary>
    /// Limits processing to the latest N problem occurrences.
    /// </summary>
    public int? LookupLimit
    {
        get => GetStruct<int>("lookupLimit");
        set => this["lookupLimit"] = value;
    }

    /// <summary>
    /// Filters by whether the problem has ever been muted.
    /// </summary>
    public bool? Muted
    {
        get => GetStruct<bool>("muted");
        set => this["muted"] = value;
    }

    /// <summary>
    /// Problem locator.
    /// </summary>
    public ProblemLocator Problem
    {
        get => Get<ProblemLocator>("problem");
        set => this["problem"] = value;
    }

    /// <summary>
    /// Problem type.
    /// </summary>
    public string Type
    {
        get => Get<string>("type");
        set => this["type"] = value;
    }
}
