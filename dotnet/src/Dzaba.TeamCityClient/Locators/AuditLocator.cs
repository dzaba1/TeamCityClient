namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering AuditEvent entities.
/// Reference: https://www.jetbrains.com/help/teamcity/rest/auditlocator.html
/// </summary>
public class AuditLocator : Locator
{
    /// <summary>
    /// Single value: event id.
    /// Written as a bare value, without the dimension name.
    /// </summary>
    public long? SingleValue
    {
        get => GetStruct<long>(SingleValueKey);
        set => this[SingleValueKey] = value;
    }

    /// <summary>
    /// Type of the action.
    /// </summary>
    public AuditLocatorAction? Action
    {
        get => GetStruct<AuditLocatorAction>("action");
        set => this["action"] = value;
    }

    /// <summary>
    /// Project locator, filters by the related project. Only single values are supported.
    /// </summary>
    public ProjectLocator AffectedProject
    {
        get => Get<ProjectLocator>("affectedProject");
        set => this["affectedProject"] = value;
    }

    /// <summary>
    /// Build type locator, filters by the related build configuration or template. Only single values are supported.
    /// </summary>
    public BuildTypeLocator BuildType
    {
        get => Get<BuildTypeLocator>("buildType");
        set => this["buildType"] = value;
    }

    /// <summary>
    /// Event id.
    /// </summary>
    public long? Id
    {
        get => GetStruct<long>("id");
        set => this["id"] = value;
    }

    /// <summary>
    /// Filters by whether TeamCity itself performed the action.
    /// </summary>
    public LocatorTriState? SystemAction
    {
        get => GetStruct<LocatorTriState>("systemAction");
        set => this["systemAction"] = value;
    }

    /// <summary>
    /// User locator, filters by the user who caused the audit event.
    /// </summary>
    public UserLocator User
    {
        get => Get<UserLocator>("user");
        set => this["user"] = value;
    }
}
