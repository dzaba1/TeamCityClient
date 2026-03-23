namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator for filtering User entities.
/// </summary>
public class UserLocator : Locator
{
    /// <summary>
    /// User group (direct or indirect parent) locator, includes the user considering group hierarchy.
    /// </summary>
    public UserGroupLocator AffectedGroup
    {
        get => Get<UserGroupLocator>("affectedGroup");
        set => this["affectedGroup"] = value;
    }

    /// <summary>
    /// User email.
    /// </summary>
    public string Email
    {
        get => Get<string>("email");
        set => this["email"] = value;
    }

    /// <summary>
    /// User group (direct parent) locator, includes the user directly.
    /// </summary>
    public UserGroupLocator Group
    {
        get => Get<UserGroupLocator>("group");
        set => this["group"] = value;
    }

    /// <summary>
    /// User id.
    /// </summary>
    public long? Id
    {
        get => GetStruct<long>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// User's last login time
    /// </summary>
    public DateTimeOffset? LastLogin
    {
        get => GetStruct<DateTimeOffset>("lastLogin");
        set => this["lastLogin"] = value;
    }

    /// <summary>
    /// User's display name
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }

    /// <summary>
    /// Property matcher
    /// </summary>
    public LocatorProperty Property
    {
        get => Get<LocatorProperty>("property");
        set => this["property"] = value;
    }

    /// <summary>
    /// User's role
    /// </summary>
    public string Role
    {
        get => Get<string>("role");
        set => this["role"] = value;
    }

    /// <summary>
    /// Username of a user.
    /// </summary>
    public string Username
    {
        get => Get<string>("username");
        set => this["username"] = value;
    }
}
