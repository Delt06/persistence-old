using System;
using JetBrains.Annotations;

namespace Persistence
{
    public abstract class Variable<T> : IVariable<T> where T : IEquatable<T>
    {
        [NotNull] public string Name { get; }
        [CanBeNull] public T DefaultValue { get; }

        public T Get(IReadOnlyStorage storage)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            if (_valid) return _value;

            _value = ReadValueFrom(storage);
            _valid = true;

            return _value;
        }

        protected abstract T ReadValueFrom([NotNull] IReadOnlyStorage storage);

        public void Set(IStorage storage, T value)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            if (_valid && _value.Equals(value)) return;

            _value = value;
            _valid = true;
            
            WriteValueTo(storage, _value);
            storage.Flush();
        }

        protected abstract void WriteValueTo(IStorage storage, T value);

        public void Invalidate()
        {
            _valid = false;
            _value = default;
        }

        protected Variable([NotNull] string name, T defaultValue = default)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DefaultValue = defaultValue;
        }

        private bool _valid = false;
        private T _value;
    }
}