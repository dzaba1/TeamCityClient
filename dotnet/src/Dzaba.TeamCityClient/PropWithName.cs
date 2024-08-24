using Newtonsoft.Json;
using System.Reflection;

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

        var attr = property.GetCustomAttribute<JsonPropertyAttribute>();
        return new PropWithName(property, attr?.PropertyName);
    }
}
