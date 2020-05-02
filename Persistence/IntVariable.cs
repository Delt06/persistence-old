namespace Persistence
{
    /// <inheritdoc />
    public sealed class IntVariable : Variable<int>
    {
        public IntVariable(string name, int defaultValue = default) : base(name, defaultValue)
        {
        }

        /// <inheritdoc />
        protected override int ReadValueFrom(IReadOnlyStorage storage)
        {
            return storage.GetInt(Name, DefaultValue);
        }

        /// <inheritdoc />
        protected override void WriteValueTo(IStorage storage, int value)
        {
            storage.SetInt(Name, value);
        }
    }
}