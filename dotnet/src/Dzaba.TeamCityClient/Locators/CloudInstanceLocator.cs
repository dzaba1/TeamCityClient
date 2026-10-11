namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering CloudInstance entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/cloudinstancelocator.html
/// </summary>
public class CloudInstanceLocator : Locator
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
    /// Agent locator, finds the instance running the agent.
    /// </summary>
    public AgentLocator Agent
    {
        get => Get<AgentLocator>("agent");
        set => this["agent"] = value;
    }

    /// <summary>
    /// Instance id as provided by the list instances call,
    /// formatted as <c>profileId:&lt;profileId&gt;,imageId:&lt;imageId&gt;,id:&lt;instanceId&gt;</c>.
    /// </summary>
    public string Id
    {
        get => Get<string>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// Cloud image locator, filters by the image corresponding to the instance.
    /// </summary>
    public CloudImageLocator Image
    {
        get => Get<CloudImageLocator>("image");
        set => this["image"] = value;
    }

    /// <summary>
    /// Network address of the instance: a DNS name or an IP address.
    /// </summary>
    public string NetworkAddress
    {
        get => Get<string>("networkAddress");
        set => this["networkAddress"] = value;
    }

    /// <summary>
    /// Cloud profile locator, filters by the profile of the instance.
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
