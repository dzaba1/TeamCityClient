using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Dzaba.TeamCityClient;

/// <summary>
/// Base interface for fields builder.
/// </summary>
public interface IFieldsBuilder
{
    /// <summary>
    /// Builds full fields string starting from root parent.
    /// </summary>
    /// <returns>Fields string.</returns>
    string Build();
}

/// <summary>
/// Typed fields builder.
/// </summary>
/// <typeparam name="T">Type</typeparam>
public sealed class FieldsBuilder<T> : IFieldsBuilder
    where T : class
{
    private readonly List<Func<string>> subBuilders = new List<Func<string>>();
    private readonly IFieldsBuilder parent;

    /// <summary>
    /// Ctor
    /// </summary>
    public FieldsBuilder()
        : this(null, null)
    {

    }

    internal FieldsBuilder(string propertyName, IFieldsBuilder parent)
    {
        PropertyName = propertyName;
        this.parent = parent;
    }

    /// <summary>
    /// Property name. If empty then probably it's a root builder.
    /// </summary>
    public string PropertyName { get; }

    /// <summary>
    /// Adds all simple fields from an object. Simple here means non-complex object types excluding string. So value types plus string.
    /// </summary>
    /// <returns>Current builder</returns>
    public FieldsBuilder<T> AddSimpleFields()
    {
        foreach (var field in Fields.EnumerateSimpleFields<T>())
        {
            subBuilders.Add(() => field);
        }

        return this;
    }

    private MemberExpression GetPropertyExpression<TElem>(Expression<Func<T, TElem>> selector)
    {
        var propExpr = selector.Body as MemberExpression;
        if (propExpr == null)
        {
            throw new InvalidOperationException("The selector doesn't point to property.");
        }
        return propExpr;
    }

    private string GetJsonPropertyName(MemberExpression propExpr)
    {
        return propExpr.Member.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? propExpr.Member.Name;
    }

    /// <summary>
    /// Adds one field from an object. Doesn't check any complex types.
    /// </summary>
    /// <typeparam name="TElem">Field type</typeparam>
    /// <param name="selector">Field selector</param>
    /// <returns>Current builder</returns>
    public FieldsBuilder<T> AddField<TElem>(Expression<Func<T, TElem>> selector)
    {
        ArgumentNullException.ThrowIfNull(selector, nameof(selector));

        var propExpr = GetPropertyExpression(selector);
        var jsonPropName = GetJsonPropertyName(propExpr);
        subBuilders.Add(() => jsonPropName);

        return this;
    }

    /// <summary>
    /// Adds and returns complex object builder for specified field.
    /// </summary>
    /// <typeparam name="TElem">Field type</typeparam>
    /// <param name="selector">Field selector</param>
    /// <returns>New builder for selected field</returns>
    public FieldsBuilder<TElem> AddComplex<TElem>(Expression<Func<T, TElem>> selector)
        where TElem : class
    {
        ArgumentNullException.ThrowIfNull(selector, nameof(selector));

        var propExpr = GetPropertyExpression(selector);
        var jsonPropName = GetJsonPropertyName(propExpr);

        var newBuilder = new FieldsBuilder<TElem>(jsonPropName, this);
        subBuilders.Add(newBuilder.ToString);

        return newBuilder;
    }

    /// <summary>
    /// Adds and returns collection builder for specified field.
    /// </summary>
    /// <typeparam name="TElem">Field type</typeparam>
    /// <param name="selector">Field selector</param>
    /// <returns>New builder for selected field</returns>
    public FieldsBuilder<TElem> AddComplex<TElem>(Expression<Func<T, ICollection<TElem>>> selector)
        where TElem : class
    {
        ArgumentNullException.ThrowIfNull(selector, nameof(selector));

        var propExpr = GetPropertyExpression(selector);
        var jsonPropName = GetJsonPropertyName(propExpr);

        var newBuilder = new FieldsBuilder<TElem>(jsonPropName, this);
        subBuilders.Add(newBuilder.ToString);

        return newBuilder;
    }

    /// <summary>
    /// Builds fields string starting from current builder. Includes all inner sub-builders. Doesn't check parent builders.
    /// </summary>
    /// <returns>Fields string.</returns>
    public override string ToString()
    {
        var fieldsStr = string.Join(",", subBuilders.Select(s => s()));

        if (string.IsNullOrWhiteSpace(PropertyName))
        {
            return fieldsStr;
        }

        return $"{PropertyName}({fieldsStr})";
    }

    /// <summary>
    /// Builds full fields string starting from root parent.
    /// </summary>
    /// <returns>Fields string.</returns>
    public string Build()
    {
        if (parent != null)
        {
            return parent.Build();
        }

        return ToString();
    }
}
