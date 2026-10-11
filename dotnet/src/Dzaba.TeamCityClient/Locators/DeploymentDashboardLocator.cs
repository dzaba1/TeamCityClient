namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering DeploymentDashboard entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/deploymentdashboardlocator.html
/// </summary>
public class DeploymentDashboardLocator : Locator
{
    /// <summary>
    /// Project locator, filters by projects in which the deployment dashboards are accessible.
    /// </summary>
    public ProjectLocator AffectedProject
    {
        get => Get<ProjectLocator>("affectedProject");
        set => this["affectedProject"] = value;
    }

    /// <summary>
    /// Dashboard id.
    /// </summary>
    public string Id
    {
        get => Get<string>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// Dashboard name.
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }

    /// <summary>
    /// Project locator, filters by projects defining the deployment dashboards.
    /// </summary>
    public ProjectLocator Project
    {
        get => Get<ProjectLocator>("project");
        set => this["project"] = value;
    }
}
