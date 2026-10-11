namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering AgentPool entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/agentpoollocator.html
/// </summary>
public class AgentPoolLocator : Locator
{
    /// <summary>
    /// Single value: agent pool id.
    /// Written as a bare value, without the dimension name.
    /// </summary>
    public long? SingleValue
    {
        get => GetStruct<long>(SingleValueKey);
        set => this[SingleValueKey] = value;
    }

    /// <summary>
    /// Agent locator, filters by the agents associated with the pool.
    /// </summary>
    public AgentLocator Agent
    {
        get => Get<AgentLocator>("agent");
        set => this["agent"] = value;
    }

    /// <summary>
    /// Agent pool id.
    /// </summary>
    public long? Id
    {
        get => GetStruct<long>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// Agent pool name.
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }

    /// <summary>
    /// Project locator, filters by the projects associated with the pool.
    /// </summary>
    public ProjectLocator Project
    {
        get => Get<ProjectLocator>("project");
        set => this["project"] = value;
    }
}
