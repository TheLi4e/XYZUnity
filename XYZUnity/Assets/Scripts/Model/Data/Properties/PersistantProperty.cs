
using UnityEngine;

namespace Scripts.Model.Data.Properties
{
    public abstract class PersistantProperty<TPropertyType>
    {
        [SerializeField] private TPropertyType _value;
        private TPropertyType _stored;

        private TPropertyType _defaultValue;

        public delegate void OnPropertyChanged(TPropertyType newValue, TPropertyType oldValue);

        public event OnPropertyChanged OnChanged;

        public PersistantProperty(TPropertyType defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public TPropertyType Value
        {
            get => _value;
            set
            {
                var isEquals = _value.Equals(value);
                if (isEquals) return;

                var oldValue = _value;
                Write(value);
                _value = value;

                OnChanged?.Invoke(value, oldValue);


            }
        }

        protected void Init()
        {
            _value = Read(_defaultValue);
        }

        protected abstract void Write(TPropertyType value);
        protected abstract TPropertyType Read(TPropertyType defaultValue);
    }
}
