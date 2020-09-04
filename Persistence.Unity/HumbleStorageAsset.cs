namespace Persistence.Unity
{
	public abstract class HumbleStorageAsset : StorageAsset
	{
		public sealed override void SetInt(string key, int value)
		{
			Storage.SetInt(key, value);
		}

		public sealed override void SetFloat(string key, float value)
		{
			Storage.SetFloat(key, value);
		}

		public sealed override void SetString(string key, string value)
		{
			Storage.SetString(key, value);
		}

		public sealed override void SetBool(string key, bool value)
		{
			Storage.SetBool(key, value);
		}

		public sealed override void Flush()
		{
			Storage.Flush();
		}

		public sealed override int GetInt(string key, int defaultValue = default) => Storage.GetInt(key, defaultValue);

		public sealed override float GetFloat(string key, float defaultValue = default) =>
			Storage.GetFloat(key, defaultValue);

		public sealed override string GetString(string key, string defaultValue = default) =>
			Storage.GetString(key, defaultValue);

		public sealed override bool GetBool(string key, bool defaultValue = default) =>
			Storage.GetBool(key, defaultValue);

		private IStorage Storage
		{
			get
			{
				if (_storage != null) return _storage;

				_storage = CreateStorage() ??
				           throw new StorageException($"{nameof(CreateStorage)} must return a non-null value.");
				return _storage;
			}
		}

		protected abstract IStorage CreateStorage();

		private IStorage _storage;
	}

	public class HumbleStorageAsset<T> : HumbleStorageAsset
		where T : class, IStorage, new()
	{
		protected sealed override IStorage CreateStorage() => new T();
	}
}