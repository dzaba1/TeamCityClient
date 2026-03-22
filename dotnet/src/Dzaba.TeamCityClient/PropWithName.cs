using System.Reflection;
using System.Text.Json.Serialization;

namespace Dzaba.TeamCityClient;

internal record PropWithName
{
    public PropWithName(MemberInfo property, string name)
    {
        ArgumentNullException.ThrowIfNull(property, nameof(property));

        Property = property;
        Name = name;
    }

    public MemberInfo Property { get; }

    public string Name { get; }

    public static PropWithName FromJsonProperty(MemberInfo property)
    {
        ArgumentNullException.ThrowIfNull(property, nameof(property));

        var attr = property.GetCustomAttribute<JsonPropertyNameAttribute>();
        return new PropWithName(property, attr?.Name);
    }
}
