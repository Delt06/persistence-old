using System;
using System.Globalization;

namespace Persistence.Extensions
{
    public static class DateTimeStorageExtensions
    {
        public static void SetDateTime(this IStorage storage, string key, DateTime value)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            if (key == null) throw new ArgumentNullException(nameof(key));

            var dateTimeAsString = value.ToString(DefaultFormatProvider);
            storage.SetString(key, dateTimeAsString);
        }

        public static DateTime GetDateTime(this IReadOnlyStorage storage, string key, DateTime defaultValue = default)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            if (key == null) throw new ArgumentNullException(nameof(key));

            var storedString = storage.GetString(key, null);
            if (storedString == null) return defaultValue;

            return DateTime.TryParse(storedString, DefaultFormatProvider, DateTimeStyles.None, out var dateTime)
                ? dateTime
                : defaultValue;
        }
        
        private static readonly IFormatProvider DefaultFormatProvider = CultureInfo.InvariantCulture; 
    }
}