namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Provides extension methods for locator objects.
/// </summary>
public static class LocatorExtensions
{
    /// <summary>
    /// Deep copy of locator fields and values.
    /// </summary>
    /// <returns>Deep copy of locator fields and values.</returns>
    public static T Copy<T>(this T locator) where T : Locator, new()
    {
        ArgumentNullException.ThrowIfNull(locator);

        var dict = locator.ToDictionary(k => k.Key, k => k.Value, Locator.DefaultKeyComparer);
        var copyLocator = new T();
        locator.SetDict(dict);
        return locator;
    }
}
