using JetBrains.Annotations;

namespace Persistence
{
    /// <inheritdoc />
    public sealed class FloatVariable : Variable<float>
    {
        public FloatVariable([NotNull] string name, float defaultValue = default) : base(name, defaultValue)
        {
        }

        /// <inheritdoc />
        protected override float ReadValueFrom(IReadOnlyStorage storage)
        {
            return storage.GetFloat(Name, DefaultValue);
        }

        /// <inheritdoc />
        protected override void WriteValueTo(IStorage storage, float value)
        {
            storage.SetFloat(Name, value);
        }
    }
}