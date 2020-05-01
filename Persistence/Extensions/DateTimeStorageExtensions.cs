using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Persistence.Extensions
{
    public static class DateTimeStorageExtensions
    {
        public static void SetDateTime([NotNull] this IStorage storage, [NotNull] string key, DateTime value)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            if (key == null) throw new ArgumentNullException(nameof(key));

            var dateTimeAsString = value.ToString(DefaultFormatProvider);
            storage.SetString(key, dateTimeAsString);
        }

        public static DateTime GetDateTime([NotNull] this IReadOnlyStorage storage, [NotNull] string key, DateTime defaultValue = default)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            if (key == null) throw new ArgumentNullException(nameof(key));

            var storedString = storage.GetString(key, null);
            if (storedString == null) return defaultValue;

            return DateTime.TryParse(storedString, DefaultFormatProvider, DateTimeStyles.None, out var dateTime)
                ? dateTime
                : defaultValue;
        }
        
        [NotNull]
        private static readonly IFormatProvider DefaultFormatProvider = CultureInfo.InvariantCulture; 
    }
}