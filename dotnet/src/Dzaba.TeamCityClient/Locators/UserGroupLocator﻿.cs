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
        get => this["key"] as string;
        set => this["key"] = value;
    }

    /// <summary>
    /// User group name
    /// </summary>
    public string Name
    {
        get => this["name"] as string;
        set => this["name"] = value;
    }
}
