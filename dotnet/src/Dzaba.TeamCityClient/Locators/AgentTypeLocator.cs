namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator for filtering AgentType entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/agenttypelocator.html
/// </summary>
public class AgentTypeLocator : Locator
{
    /// <summary>
    /// Single value: id of the AgentType.
    /// Written as a bare value, without the dimension name.
    /// </summary>
    public string SingleValue
    {
        get => Get<string>(SingleValueKey);
        set => this[SingleValueKey] = value;
    }

    /// <summary>
    /// Locator of an agent, filters by the AgentType of the given agent.
    /// </summary>
    public AgentLocator Agent
    {
        get => Get<AgentLocator>("agent");
        set => this["agent"] = value;
    }

    /// <summary>
    /// AgentType id.
    /// </summary>
    public long? Id
    {
        get => GetStruct<long>("id");
        set => this["id"] = value;
    }
}
