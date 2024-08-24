using System.Reflection;

namespace Dzaba.TeamCityClient;

/// <summary>
/// Helper methods for getting fields to locators.
/// </summary>
public static class Fields
{
    /// <summary>
    /// Gets all simple fields from an object. Simple here means non-complex object types excluding string. So value types plus string.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetSimpleFields<T>() where T : class
    {
        var props = GetProps<T>()
            .Where(p =>
            {
                var prop = (PropertyInfo)p.Property;
                var typeToTest = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                var typeCode = Type.GetTypeCode(typeToTest);
                return typeCode != TypeCode.Object;
            });

        return string.Join(",", props.Select(p => p.Name));
    }

    internal static string BuildFieldsString(IEnumerable<PropWithName> props)
    {
        return string.Join(",", props.Select(p => p.Name));
    }

    private static IEnumerable<PropWithName> GetProps<T>()
    {
        return typeof(T)
            .GetProperties()
            .Select(PropWithName.FromJsonProperty)
            .Where(p => !string.IsNullOrWhiteSpace(p.Name));
    }
}
