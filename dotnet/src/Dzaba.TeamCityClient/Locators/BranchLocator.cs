namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering Branch entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/branchlocator.html
/// </summary>
public class BranchLocator : Locator
{
    /// <summary>
    /// Single value: branch name.
    /// Written as a bare value, without the dimension name.
    /// </summary>
    public string SingleValue
    {
        get => Get<string>(SingleValueKey);
        set => this[SingleValueKey] = value;
    }

    /// <summary>
    /// Build locator, finds the branch that the build was started with.
    /// </summary>
    public BuildLocator Build
    {
        get => Get<BuildLocator>("build");
        set => this["build"] = value;
    }

    /// <summary>
    /// Build type locator, finds the branches of the build configuration.
    /// </summary>
    public BuildTypeLocator BuildType
    {
        get => Get<BuildTypeLocator>("buildType");
        set => this["buildType"] = value;
    }

    /// <summary>
    /// Filters by whether to include branches from dependencies.
    /// </summary>
    public LocatorTriState? ChangesFromDependencies
    {
        get => GetStruct<LocatorTriState>("changesFromDependencies");
        set => this["changesFromDependencies"] = value;
    }

    /// <summary>
    /// Filters by whether the branch is the default branch.
    /// </summary>
    public LocatorTriState? Default
    {
        get => GetStruct<LocatorTriState>("default");
        set => this["default"] = value;
    }

    /// <summary>
    /// Branch name condition.
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }

    /// <summary>
    /// Branch retrieval policy.
    /// </summary>
    public BranchLocatorPolicy? Policy
    {
        get => GetStruct<BranchLocatorPolicy>("policy");
        set => this["policy"] = value;
    }

    /// <summary>
    /// Filters by whether the branch is unspecified, i.e. TeamCity failed to find an appropriate branch name for the build.
    /// </summary>
    public LocatorTriState? Unspecified
    {
        get => GetStruct<LocatorTriState>("unspecified");
        set => this["unspecified"] = value;
    }
}
