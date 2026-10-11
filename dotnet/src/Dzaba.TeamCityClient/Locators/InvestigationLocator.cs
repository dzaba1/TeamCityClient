namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering Investigation entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/investigationlocator.html
/// </summary>
public class InvestigationLocator : Locator
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
    /// Project locator, includes sub-projects as well as parent projects.
    /// </summary>
    public ProjectLocator AffectedProjectAndParents
    {
        get => Get<ProjectLocator>("affectedProjectAndParents");
        set => this["affectedProjectAndParents"] = value;
    }

    /// <summary>
    /// User locator, filters by the assigned user.
    /// </summary>
    public UserLocator Assignee
    {
        get => Get<UserLocator>("assignee");
        set => this["assignee"] = value;
    }

    /// <summary>
    /// Project locator, filters by the direct parent project of the assignment.
    /// </summary>
    public ProjectLocator AssignmentProject
    {
        get => Get<ProjectLocator>("assignmentProject");
        set => this["assignmentProject"] = value;
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
    /// Problem locator.
    /// </summary>
    public ProblemLocator Problem
    {
        get => Get<ProblemLocator>("problem");
        set => this["problem"] = value;
    }

    /// <summary>
    /// User locator, filters by the reporting user.
    /// </summary>
    public UserLocator Reporter
    {
        get => Get<UserLocator>("reporter");
        set => this["reporter"] = value;
    }

    /// <summary>
    /// Investigation resolution.
    /// </summary>
    public InvestigationLocatorResolution? Resolution
    {
        get => GetStruct<InvestigationLocatorResolution>("resolution");
        set => this["resolution"] = value;
    }

    /// <summary>
    /// Filters by the date since which the investigation exists.
    /// </summary>
    public DateTimeOffset? SinceDate
    {
        get => GetStruct<DateTimeOffset>("sinceDate");
        set => this["sinceDate"] = value;
    }

    /// <summary>
    /// Investigation state.
    /// </summary>
    public InvestigationLocatorState? State
    {
        get => GetStruct<InvestigationLocatorState>("state");
        set => this["state"] = value;
    }

    /// <summary>
    /// Test locator.
    /// </summary>
    public TestLocator Test
    {
        get => Get<TestLocator>("test");
        set => this["test"] = value;
    }

    /// <summary>
    /// Investigation type.
    /// </summary>
    public InvestigationLocatorType? Type
    {
        get => GetStruct<InvestigationLocatorType>("type");
        set => this["type"] = value;
    }
}
