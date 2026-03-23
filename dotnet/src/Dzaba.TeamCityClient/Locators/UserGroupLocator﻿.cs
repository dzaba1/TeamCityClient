namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Represents a locator string for filtering Group entities
/// </summary>
public class UserGroupLocator﻿ : Locator
{
    /// <summary>
    /// User group key
    /// </summary>
    public string Key
    {
        get => Get<string>("key");
        set => this["key"] = value;
    }

    /// <summary>
    /// User group name
    /// </summary>
    public string Name
    {
        get => Get<string>("name");
        set => this["name"] = value;
    }
}
