namespace Persistence
{
	/// <inheritdoc />
	public sealed class FloatVariable : Variable<float>
	{
		public FloatVariable(string name, float defaultValue = default) : base(name, defaultValue) { }

		/// <inheritdoc />
		protected override float ReadValueFrom(IReadOnlyStorage storage) => storage.GetFloat(Name, DefaultValue);

		/// <inheritdoc />
		protected override void WriteValueTo(IStorage storage, float value)
		{
			storage.SetFloat(Name, value);
		}
	}
}