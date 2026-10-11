using System.Runtime.Serialization;

namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Property match type.
/// </summary>
public enum LocatorPropertyType
{
    /// <summary>
    /// The property exists.
    /// </summary>
    [EnumMember(Value = "exists")]
    Exists,

    /// <summary>
    /// The property does not exist.
    /// </summary>
    [EnumMember(Value = "not-exists")]
    NotExists,

    /// <summary>
    /// The property value equals the given value.
    /// </summary>
    [EnumMember(Value = "equals")]
    Equals,

    /// <summary>
    /// The property value does not equal the given value.
    /// </summary>
    [EnumMember(Value = "does-not-equal")]
    DoesNotEqual,

    /// <summary>
    /// The property value starts with the given value.
    /// </summary>
    [EnumMember(Value = "starts-with")]
    StartsWith,

    /// <summary>
    /// The property value contains the given value.
    /// </summary>
    [EnumMember(Value = "contains")]
    Contains,

    /// <summary>
    /// The property value does not contain the given value.
    /// </summary>
    [EnumMember(Value = "does-not-contain")]
    DoesNotContain,

    /// <summary>
    /// The property value ends with the given value.
    /// </summary>
    [EnumMember(Value = "ends-with")]
    EndsWith,

    /// <summary>
    /// Any property value matches.
    /// </summary>
    [EnumMember(Value = "any")]
    Any,

    /// <summary>
    /// The property value matches the given regular expression.
    /// </summary>
    [EnumMember(Value = "matches")]
    Matches,

    /// <summary>
    /// The property value does not match the given regular expression.
    /// </summary>
    [EnumMember(Value = "does-not-match")]
    DoesNotMatch,

    /// <summary>
    /// The property value is greater than the given value.
    /// </summary>
    [EnumMember(Value = "more-than")]
    MoreThan,

    /// <summary>
    /// The property value is not greater than the given value.
    /// </summary>
    [EnumMember(Value = "no-more-than")]
    NoMoreThan,

    /// <summary>
    /// The property value is less than the given value.
    /// </summary>
    [EnumMember(Value = "less-than")]
    LessThan,

    /// <summary>
    /// The property value is not less than the given value.
    /// </summary>
    [EnumMember(Value = "no-less-than")]
    NoLessThan,

    /// <summary>
    /// The property value, compared as a version, is greater than the given version.
    /// </summary>
    [EnumMember(Value = "ver-more-than")]
    VerMoreThan,

    /// <summary>
    /// The property value, compared as a version, is not greater than the given version.
    /// </summary>
    [EnumMember(Value = "ver-no-more-than")]
    VerNoMoreThan,

    /// <summary>
    /// The property value, compared as a version, is less than the given version.
    /// </summary>
    [EnumMember(Value = "ver-less-than")]
    VerLessThan,

    /// <summary>
    /// The property value, compared as a version, is not less than the given version.
    /// </summary>
    [EnumMember(Value = "ver-no-less-than")]
    VerNoLessThan
}
