namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents the value of the <c>compatible</c> dimension of <see cref="AgentLocator"/> (CompatibleDimensions).
/// Formatted as <c>buildType:(locator)</c>.
/// </summary>
public class AgentCompatibleLocator : Locator
{
    /// <summary>
    /// Build type locator, filters by agents compatible with the build configuration.
    /// </summary>
    public BuildTypeLocator BuildType
    {
        get => Get<BuildTypeLocator>("buildType");
        set => this["buildType"] = value;
    }
}
