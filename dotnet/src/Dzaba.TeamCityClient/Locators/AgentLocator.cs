namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering Agent entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/agentlocator.html
/// </summary>
public class AgentLocator : Locator
{
    /// <summary>
    /// Single value: agent name.
    /// Written as a bare value, without the dimension name.
    /// </summary>
    public string SingleValue
    {
        get => Get<string>(SingleValueKey);
        set => this[SingleValueKey] = value;
    }

    /// <summary>
    /// Filters by whether the agent is authorized.
    /// </summary>
    public LocatorTriState? Authorized
    {
        get => GetStruct<LocatorTriState>("authorized");
        set => this["authorized"] = value;
    }

    /// <summary>
    /// Build locator of a build which ran on this agent (or is compatible with for queued builds).
    /// </summary>
    public BuildLocator Build
    {
        get => Get<BuildLocator>("build");
        set => this["build"] = value;
    }

    /// <summary>
    /// Compatible build types locator.
    /// </summary>
    public AgentCompatibleLocator Compatible
    {
        get => Get<AgentCompatibleLocator>("compatible");
        set => this["compatible"] = value;
    }

    /// <summary>
    /// Filters by whether the agent is connected.
    /// </summary>
    public LocatorTriState? Connected
    {
        get => GetStruct<LocatorTriState>("connected");
        set => this["connected"] = value;
    }

    /// <summary>
    /// Filters by whether the agent is enabled.
    /// </summary>
    public LocatorTriState? Enabled
    {
        get => GetStruct<LocatorTriState>("enabled");
        set => this["enabled"] = value;
    }

    /// <summary>
    /// Agent id.
    /// </summary>
    public long? Id
    {
        get => GetStruct<long>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// Agent ip address.
    /// </summary>
    public string Ip
    {
        get => Get<string>("ip");
        set => this["ip"] = value;
    }

    /// <summary>
    /// Agent name.
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }

    /// <summary>
    /// Matching parameter.
    /// </summary>
    public LocatorProperty<LocatorPropertyType> Parameter
    {
        get => Get<LocatorProperty<LocatorPropertyType>>("parameter");
        set => this["parameter"] = value;
    }

    /// <summary>
    /// Agent pool locator.
    /// </summary>
    public AgentPoolLocator Pool
    {
        get => Get<AgentPoolLocator>("pool");
        set => this["pool"] = value;
    }
}
