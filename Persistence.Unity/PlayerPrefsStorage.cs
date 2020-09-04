using System;
using UnityEngine;

namespace Persistence.Unity
{
	/// <summary>
	/// Provides a storage interface to the Unity's PlayerPrefs.
	/// </summary>
	public sealed class PlayerPrefsStorage : IStorage
	{
		public void SetInt(string key, int value)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			PlayerPrefs.SetInt(key, value);
		}

		public void SetFloat(string key, float value)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			PlayerPrefs.SetFloat(key, value);
		}

		public void SetString(string key, string value)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			PlayerPrefs.SetString(key, value);
		}

		public void SetBool(string key, bool value)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			PlayerPrefs.SetInt(key, value ? 1 : 0);
		}

		public int GetInt(string key, int defaultValue = default)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			return PlayerPrefs.GetInt(key, defaultValue);
		}

		public float GetFloat(string key, float defaultValue = default)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			return PlayerPrefs.GetFloat(key, defaultValue);
		}

		public string GetString(string key, string defaultValue = default)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			return PlayerPrefs.GetString(key, defaultValue);
		}

		public bool GetBool(string key, bool defaultValue = default)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) != 0;
		}

		/// <inheritdoc />
		public void Flush() => PlayerPrefs.Save();
	}
}