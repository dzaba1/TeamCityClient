namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering CloudImage entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/cloudimagelocator.html
/// </summary>
public class CloudImageLocator : Locator
{
    /// <summary>
    /// Project locator, filters by projects where the cloud profiles/images are accessible.
    /// </summary>
    public ProjectLocator AffectedProject
    {
        get => Get<ProjectLocator>("affectedProject");
        set => this["affectedProject"] = value;
    }

    /// <summary>
    /// Agent locator.
    /// </summary>
    public AgentLocator Agent
    {
        get => Get<AgentLocator>("agent");
        set => this["agent"] = value;
    }

    /// <summary>
    /// Agent pool locator.
    /// </summary>
    public AgentPoolLocator AgentPool
    {
        get => Get<AgentPoolLocator>("agentPool");
        set => this["agentPool"] = value;
    }

    /// <summary>
    /// Agent type locator.
    /// </summary>
    public AgentTypeLocator AgentType
    {
        get => Get<AgentTypeLocator>("agentType");
        set => this["agentType"] = value;
    }

    /// <summary>
    /// Build promotion locator.
    /// </summary>
    public BuildLocator CompatibleBuildPromotion
    {
        get => Get<BuildLocator>("compatibleBuildPromotion");
        set => this["compatibleBuildPromotion"] = value;
    }

    /// <summary>
    /// Build type locator.
    /// </summary>
    public BuildTypeLocator CompatibleBuildType
    {
        get => Get<BuildTypeLocator>("compatibleBuildType");
        set => this["compatibleBuildType"] = value;
    }

    /// <summary>
    /// Image id as provided by the list images call.
    /// </summary>
    public string Id
    {
        get => Get<string>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// Cloud instance locator.
    /// </summary>
    public CloudInstanceLocator Instance
    {
        get => Get<CloudInstanceLocator>("instance");
        set => this["instance"] = value;
    }

    /// <summary>
    /// Image name condition.
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }

    /// <summary>
    /// Cloud profile locator.
    /// </summary>
    public CloudProfileLocator Profile
    {
        get => Get<CloudProfileLocator>("profile");
        set => this["profile"] = value;
    }

    /// <summary>
    /// Project locator, filters by projects defining the cloud profiles/images.
    /// </summary>
    public ProjectLocator Project
    {
        get => Get<ProjectLocator>("project");
        set => this["project"] = value;
    }

    /// <summary>
    /// Property matcher.
    /// </summary>
    public LocatorProperty<LocatorPropertyType> Property
    {
        get => Get<LocatorProperty<LocatorPropertyType>>("property");
        set => this["property"] = value;
    }
}
