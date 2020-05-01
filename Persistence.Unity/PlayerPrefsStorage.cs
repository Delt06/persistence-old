using System;
using UnityEngine;

namespace Persistence.Unity
{
    /// <summary>
    /// SciptableObject that provides a storage interface to the Unity's PlayerPrefs.
    /// </summary>
    [CreateAssetMenu]
    public sealed class PlayerPrefsStorage : Storage
    {
        public override void SetInt(string key, int value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            
            PlayerPrefs.SetInt(key, value);
        }

        public override void SetFloat(string key, float value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            
            PlayerPrefs.SetFloat(key, value);
        }

        public override void SetString(string key, string value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            
            PlayerPrefs.SetString(key, value);
        }

        public override void SetBool(string key, bool value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        public override int GetInt(string key, int defaultValue = default)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public override float GetFloat(string key, float defaultValue = default)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            return PlayerPrefs.GetFloat(key, defaultValue);
        }

        public override string GetString(string key, string defaultValue = default)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            return PlayerPrefs.GetString(key, defaultValue);
        }

        public override bool GetBool(string key, bool defaultValue = default)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) != 0;
        }

        /// <inheritdoc />
        public override void Flush() => PlayerPrefs.Save();
    }
}