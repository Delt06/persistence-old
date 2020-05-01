using JetBrains.Annotations;

namespace Persistence
{
    /// <summary>
    /// A read-write storage.
    /// </summary>
    public interface IStorage : IReadOnlyStorage
    {
        void SetInt([NotNull] string key, int value);
        void SetFloat([NotNull] string key, float value);
        void SetString([NotNull] string key, [CanBeNull] string value);
        void SetBool([NotNull] string key, bool value);
        
        /// <summary>
        /// Write buffered values.
        /// </summary>
        void Flush();
    }
}