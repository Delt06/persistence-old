using JetBrains.Annotations;

namespace Persistence
{
    /// <summary>
    /// A read-only storage.
    /// </summary>
    public interface IReadOnlyStorage
    {
        int GetInt([NotNull] string key, int defaultValue = default);
        float GetFloat([NotNull] string key, float defaultValue = default);
        string GetString([NotNull] string key, [CanBeNull] string defaultValue = default);
        bool GetBool([NotNull] string key, bool defaultValue = default);
    }
}