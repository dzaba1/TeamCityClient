namespace Dzaba.TeamCityClient
{
    /// <summary>
    /// Base locator class helper.
    /// </summary>
    public class Locator
    {
        private readonly Dictionary<string, object> dict;
        private readonly StringComparer keyComparer;

        /// <summary>
        /// Ctor
        /// </summary>
        public Locator()
            : this(StringComparer.Ordinal)
        {

        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="keyComparer">Comparer used for field names</param>
        public Locator(StringComparer keyComparer)
        {
            ArgumentNullException.ThrowIfNull(keyComparer, nameof(keyComparer));

            this.keyComparer = keyComparer;
            dict = new Dictionary<string, object>(keyComparer);
        }

        internal Locator(Dictionary<string, object> dict)
        {
            ArgumentNullException.ThrowIfNull(dict, nameof(dict));

            this.dict = dict;
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

        /// <summary>
        /// Deep copy of locator fields and values.
        /// </summary>
        /// <returns>Deep copy of locator fields and values.</returns>
        public Locator Copy()
        {
            var copyDict = dict.ToDictionary(k => k.Key, k => k.Value, keyComparer);
            return new Locator(copyDict);
        }

        /// <summary>
        /// Page count
        /// </summary>
        public int? Count
        {
            get => GetStruct<int>("count");
            set => this["count"] = value;
        }

        /// <summary>
        /// Page start
        /// </summary>
        public int? Start
        {
            get => GetStruct<int>("start");
            set => this["start"] = value;
        }
    }
}
