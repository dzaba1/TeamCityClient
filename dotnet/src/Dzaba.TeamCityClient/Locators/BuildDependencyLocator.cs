namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents the value of the <c>snapshotDependency</c> and <c>artifactDependency</c> dimensions of <see cref="BuildLocator"/>.
/// Formatted as <c>to:(locator),from:(locator)</c>.
/// </summary>
public class BuildDependencyLocator : Locator
{
    /// <summary>
    /// Build locator of the build the dependency comes from.
    /// </summary>
    public BuildLocator From
    {
        get => Get<BuildLocator>("from");
        set => this["from"] = value;
    }

    /// <summary>
    /// Build locator of the build the dependency leads to.
    /// </summary>
    public BuildLocator To
    {
        get => Get<BuildLocator>("to");
        set => this["to"] = value;
    }
}
