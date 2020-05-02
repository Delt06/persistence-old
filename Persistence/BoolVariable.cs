namespace Persistence
{
    /// <inheritdoc />
    public sealed class BoolVariable : Variable<bool>
    {
        public BoolVariable(string name, bool defaultValue = default) : base(name, defaultValue)
        {
        }

        /// <inheritdoc />
        protected override bool ReadValueFrom(IReadOnlyStorage storage)
        {
            return storage.GetBool(Name, DefaultValue);
        }

        /// <inheritdoc />
        protected override void WriteValueTo(IStorage storage, bool value)
        {
            storage.SetBool(Name, value);
        }
    }
}