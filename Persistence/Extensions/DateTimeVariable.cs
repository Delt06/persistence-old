using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Persistence.Extensions
{
    /// <inheritdoc />
    public sealed class DateTimeVariable : Variable<DateTime>
    {
        public DateTimeVariable([NotNull] string name, DateTime defaultValue = default) : base(name, defaultValue)
        {
        }

        protected override DateTime ReadValueFrom(IReadOnlyStorage storage)
        {
            return storage.GetDateTime(Name, DefaultValue);
        }

        protected override void WriteValueTo(IStorage storage, DateTime value)
        {
            storage.SetDateTime(Name, value);
        }
    }
}