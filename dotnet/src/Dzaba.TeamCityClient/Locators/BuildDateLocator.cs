namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a date condition used by <see cref="BuildLocator"/> dimensions: <c>startDate</c>, <c>finishDate</c> and <c>queuedDate</c>.
/// Requires either <see cref="Date"/> or <see cref="Build"/> to be set.
/// Formatted as <c>date:yyyyMMddTHHmmss+ZZZZ,build:(locator),condition:before/after</c>.
/// </summary>
public class BuildDateLocator : Locator
{
    /// <summary>
    /// Date to compare to.
    /// </summary>
    public DateTimeOffset? Date
    {
        get => GetStruct<DateTimeOffset>("date");
        set => this["date"] = value;
    }

    /// <summary>
    /// Build whose date is compared to.
    /// </summary>
    public BuildLocator Build
    {
        get => Get<BuildLocator>("build");
        set => this["build"] = value;
    }

    /// <summary>
    /// Comparison condition. Supported values: <c>before</c>, <c>after</c>.
    /// </summary>
    public string Condition
    {
        get => Get<string>("condition");
        set => this["condition"] = value;
    }
}
