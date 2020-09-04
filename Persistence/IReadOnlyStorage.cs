namespace Persistence
{
	/// <summary>
	/// A read-only storage.
	/// </summary>
	public interface IReadOnlyStorage
	{
		int GetInt(string key, int defaultValue = default);
		float GetFloat(string key, float defaultValue = default);
		string GetString(string key, string defaultValue = default);
		bool GetBool(string key, bool defaultValue = default);
	}
}