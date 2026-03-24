namespace Dzaba.TeamCityClient;

/// <summary>
/// Helper methods for getting fields to locators.
/// </summary>
public static class Fields
{
    /// <summary>
    /// Gets all simple fields from an object. Simple here means non-complex object types excluding string. So value types plus string.
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <returns>Enumerable of strings</returns>
    public static IEnumerable<string> EnumerateSimpleFields<T>() where T : class
    {
        return EnumerateSimpleFields(typeof(T));
    }

    /// <summary>
    /// Gets all simple fields from an object. Simple here means non-complex object types excluding string. So value types plus string.
    /// </summary>
    /// <param name="type">Type</param>
    /// <returns>Enumerable of strings</returns>
    public static IEnumerable<string> EnumerateSimpleFields(System.Type type)
    {
        ArgumentNullException.ThrowIfNull(type, nameof(type));

        var props = GetProps(type)
            .Where(p =>
            {
                var typeToTest = Nullable.GetUnderlyingType(p.Property.PropertyType) ?? p.Property.PropertyType;

                var typeCode = System.Type.GetTypeCode(typeToTest);
                return typeCode != TypeCode.Object;
            });

        return props.Select(p => p.Name);
    }

    /// <summary>
    /// Gets all simple fields from an object. Simple here means non-complex object types excluding string. So value types plus string.
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <returns>Comma separated string</returns>
    public static string GetSimpleFields<T>() where T : class
    {
        return string.Join(",", EnumerateSimpleFields<T>());
    }

    /// <summary>
    /// Gets all simple fields from an object. Simple here means non-complex object types excluding string. So value types plus string.
    /// </summary>
    /// <param name="type">Type</param>
    /// <returns>Comma separated string</returns>
    public static string GetSimpleFields(System.Type type)
    {
        return string.Join(",", EnumerateSimpleFields(type));
    }

    private static IEnumerable<PropWithName> GetProps(System.Type type)
    {
        return type
            .GetProperties()
            .Select(PropWithName.FromJsonProperty)
            .Where(p => !string.IsNullOrWhiteSpace(p.Name));
    }
}
