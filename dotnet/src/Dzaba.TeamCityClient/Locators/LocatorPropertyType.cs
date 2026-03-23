using System.Runtime.Serialization;

namespace Dzaba.TeamCityClient.Locators;

/// <summary>
/// Property match type.
/// </summary>
public enum LocatorPropertyType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [EnumMember(Value = "exists")]
    Exists,

    [EnumMember(Value = "not-exists")]
    NotExists,

    [EnumMember(Value = "equals")]
    Equals,

    [EnumMember(Value = "does-not-equal")]
    DoesNotEqual,

    [EnumMember(Value = "starts-with")]
    StartsWith,

    [EnumMember(Value = "contains")]
    Contains,

    [EnumMember(Value = "does-not-contain")]
    DoesNotContain,

    [EnumMember(Value = "ends-with")]
    EndsWith,

    [EnumMember(Value = "any")]
    Any,

    [EnumMember(Value = "matches")]
    Matches,

    [EnumMember(Value = "does-not-match")]
    DoesNotMatch,

    [EnumMember(Value = "more-than")]
    MoreThan,

    [EnumMember(Value = "no-more-than")]
    NoMoreThan,

    [EnumMember(Value = "less-than")]
    LessThan,

    [EnumMember(Value = "no-less-than")]
    NoLessThan,

    [EnumMember(Value = "ver-more-than")]
    VerMoreThan,

    [EnumMember(Value = "ver-no-more-than")]
    VerNoMoreThan,

    [EnumMember(Value = "ver-less-than")]
    VerLessThan,

    [EnumMember(Value = "ver-no-less-than")]
    VerNoLessThan
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}