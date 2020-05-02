# ```Persistence```

A library that provides a convenient facade for arbitrary storage mechanisms.
- Non-persistent storage: ```MemoryStorage```.
- Variables: ```Variable<T>```.

# ```Persistence.Unity```

An adapter for Unity.
- Storage as ```ScriptableObject```: ```StorageAsset```.
- Humble Object pattern: ```HumbleStorageAsset```.
- ```HumbleStorageAsset<T>``` is an implementation of ```HumbleStorageAsset```, which create a storage of type ```T``` (it must have a parameter-less constructor). 
- ```PlayerPrefs```-based storage: ```PlayerPrefsStorage``` and corresponding ```PlayerPrefsStorageAsset```.

# ```Persistence.Tests```

Test suit for the ```Persistence``` project.