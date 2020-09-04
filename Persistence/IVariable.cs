using System;

namespace Persistence
{
	/// <summary>
	/// Represents a named variable.
	/// </summary>
	/// <typeparam name="T">Type of the variable.</typeparam>
	public interface IVariable<T> where T : IEquatable<T>
	{
		/// <summary>
		/// Name of the variable (should be unique).
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Value that is returned when nothing is found in the storage.
		/// </summary>
		T DefaultValue { get; }

		/// <summary>
		/// Try to read value from the specified storage.
		/// </summary>
		/// <param name="storage">Storage to read from.</param>
		/// <returns>Stored value. If nothing is stored, <c>DefaultValue</c></returns>
		T Get(IReadOnlyStorage storage);

		/// <summary>
		/// Write value to the specified storage.
		/// </summary>
		/// <param name="storage">Storage to write to.</param>
		/// <param name="value">Value to write.</param>
		void Set(IStorage storage, T value);

		/// <summary>
		/// Clear cached value.
		/// </summary>
		void Invalidate();
	}
}