using UnityEngine;

namespace Persistence.Unity
{
    /// <summary>
    /// SciptableObject storage.
    /// </summary>
    public abstract class StorageAsset : ScriptableObject, IStorage
    {
        public abstract void SetInt(string key, int value);
        public abstract void SetFloat(string key, float value);
        public abstract void SetString(string key, string value);
        public abstract void SetBool(string key, bool value);
        
        public abstract int GetInt(string key, int defaultValue = default);
        public abstract float GetFloat(string key, float defaultValue = default);
        public abstract string GetString(string key, string defaultValue = default);
        public abstract bool GetBool(string key, bool defaultValue = default);

        /// <inheritdoc />
        public abstract void Flush();
    }
}