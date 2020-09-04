using System;
using System.Collections.Generic;

namespace Persistence
{
	/// <summary>
	/// Non-persistent storage.
	/// </summary>
	public sealed class MemoryStorage : IStorage
	{
		public int GetInt(string key, int defaultValue = default)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			return _integers.TryGetValue(key, out var value) ? value : defaultValue;
		}

		public float GetFloat(string key, float defaultValue = default)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			return _floats.TryGetValue(key, out var value) ? value : defaultValue;
		}

		public string GetString(string key, string defaultValue = default)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			return _strings.TryGetValue(key, out var value) ? value : defaultValue;
		}

		public bool GetBool(string key, bool defaultValue = default)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			return _booleans.TryGetValue(key, out var value) ? value : defaultValue;
		}

		public void SetInt(string key, int value)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			_integers[key] = value;
		}

		public void SetFloat(string key, float value)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			_floats[key] = value;
		}

		public void SetString(string key, string value)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			_strings[key] = value;
		}

		public void SetBool(string key, bool value)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));

			_booleans[key] = value;
		}

		/// <inheritdoc />
		public void Flush() { }

		public Dictionary<string, object> ToDictionary()
		{
			var dictionary = new Dictionary<string, object>();

			foreach (var pair in _integers)
			{
				dictionary[pair.Key] = pair.Value;
			}

			foreach (var pair in _booleans)
			{
				dictionary[pair.Key] = pair.Value;
			}

			foreach (var pair in _floats)
			{
				dictionary[pair.Key] = pair.Value;
			}

			foreach (var pair in _strings)
			{
				dictionary[pair.Key] = pair.Value;
			}

			return dictionary;
		}

		private readonly IDictionary<string, int> _integers = new Dictionary<string, int>();
		private readonly IDictionary<string, bool> _booleans = new Dictionary<string, bool>();
		private readonly IDictionary<string, float> _floats = new Dictionary<string, float>();
		private readonly IDictionary<string, string> _strings = new Dictionary<string, string>();
	}
}