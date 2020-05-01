using JetBrains.Annotations;

namespace Persistence
{
    /// <inheritdoc />
    public sealed class StringVariable : Variable<string>
    {
        public StringVariable([NotNull] string name, string defaultValue = default) : base(name, defaultValue)
        {
        }

        /// <inheritdoc />
        protected override string ReadValueFrom(IReadOnlyStorage storage)
        {
            return storage.GetString(Name, DefaultValue);
        }

        /// <inheritdoc />
        protected override void WriteValueTo(IStorage storage, string value)
        {
            storage.SetString(value, value);
        }
    }
}