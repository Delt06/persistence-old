namespace Persistence
{
    /// <summary>
    /// A read-write storage.
    /// </summary>
    public interface IStorage : IReadOnlyStorage
    {
        void SetInt(string key, int value);
        void SetFloat(string key, float value);
        void SetString(string key, string value);
        void SetBool(string key, bool value);
        
        /// <summary>
        /// Write buffered values.
        /// </summary>
        void Flush();
    }
}