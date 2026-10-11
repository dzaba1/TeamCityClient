namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering DeploymentInstance entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/deploymentinstancelocator.html
/// </summary>
public class DeploymentInstanceLocator : Locator
{
    /// <summary>
    /// Current state of the deployment.
    /// </summary>
    public DeploymentInstanceLocatorCurrentState? CurrentState
    {
        get => GetStruct<DeploymentInstanceLocatorCurrentState>("currentState");
        set => this["currentState"] = value;
    }

    /// <summary>
    /// Deployment dashboard locator.
    /// </summary>
    public DeploymentDashboardLocator Dashboard
    {
        get => Get<DeploymentDashboardLocator>("dashboard");
        set => this["dashboard"] = value;
    }

    /// <summary>
    /// Deployment instance id.
    /// </summary>
    public string Id
    {
        get => Get<string>("id");
        set => this["id"] = value;
    }
}
