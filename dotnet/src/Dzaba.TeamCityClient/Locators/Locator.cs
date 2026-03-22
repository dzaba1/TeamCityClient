using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Dzaba.TeamCityClient.Locators
{
    /// <summary>
    /// Base locator class helper.
    /// </summary>
    public class Locator : IReadOnlyDictionary<string, object>
    {
        internal static readonly StringComparer DefaultKeyComparer = StringComparer.Ordinal;

        private Dictionary<string, object> dict;

        /// <summary>
        /// Ctor
        /// </summary>
        public Locator()
        {
            dict = new Dictionary<string, object>(DefaultKeyComparer);
        }

        /// <summary>
        /// Returns a current field value.
        /// </summary>
        /// <param name="key">Field name</param>
        /// <returns>Field value. Null when value is not specified.</returns>
        public object this[string key]
        {
            get => dict.GetValueOrDefault(key);
            set => dict[key] = value;
        }

        /// <summary>
        /// Returns a current field value as value type.
        /// </summary>
        /// <typeparam name="T">Value type</typeparam>
        /// <param name="key">Field name</param>
        /// <returns>Field value. Null when value is not specified.</returns>
        public T? GetStruct<T>(string key)
            where T : struct
        {
            var value = this[key];
            if (value == null)
            {
                return null;
            }
            return (T)value;
        }

        /// <summary>
        /// Builds the locator string.
        /// </summary>
        /// <returns>Locator string.</returns>
        public override string ToString()
        {
            var entries = dict.Select(k => $"{k.Key}:{k.Value}");
            return string.Join(",", entries);
        }

        internal void SetDict(Dictionary<string, object> copyDict)
        {
            ArgumentNullException.ThrowIfNull(copyDict);

            dict = copyDict;
        }

        /// <inheritdoc/>
        public bool ContainsKey(string key)
        {
            return dict.ContainsKey(key);
        }

        /// <inheritdoc/>
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out object value)
        {
            return dict.TryGetValue(key, out value);
        }

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return dict.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dict.GetEnumerator();
        }

        /// <summary>
        /// Page count
        /// </summary>
        public int? PageCount
        {
            get => GetStruct<int>("count");
            set => this["count"] = value;
        }

        /// <summary>
        /// Page start
        /// </summary>
        public int? PageStart
        {
            get => GetStruct<int>("start");
            set => this["start"] = value;
        }

        /// <inheritdoc/>
        public IEnumerable<string> Keys => dict.Keys;

        /// <inheritdoc/>
        public IEnumerable<object> Values => dict.Values;

        /// <inheritdoc/>
        public int Count => dict.Count;
    }
}
