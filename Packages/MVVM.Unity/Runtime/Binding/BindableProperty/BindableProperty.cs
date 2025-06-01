using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;

namespace MVVM.Unity.Binding.BindableProperty
{
    [PublicAPI]
    public sealed class BindableProperty<TValue> : IReadOnlyBindableProperty<TValue>
    {
        private TValue _value;
        private HashSet<BindablePropertyChanged<TValue>> _callbacks;

        public TValue Value
        {
            get => _value;
            set => SetValue(ref value);
        }

        public bool RaisePropertyChanged { get; set; } = true;

        public BindableProperty(TValue value = default)
        {
            Value = value;
            _callbacks = null;
        }

        public void StartObserving(BindablePropertyChanged<TValue> callback, bool invokeOnObserve = true)
        {
            _callbacks ??= new HashSet<BindablePropertyChanged<TValue>>();

            if (!_callbacks.Add(callback))
                return;

            if (invokeOnObserve)
            {
                callback(default, Value);
            }
        }

        public void StopObserving(BindablePropertyChanged<TValue> callback)
        {
            if (_callbacks == null || !_callbacks.Contains(callback))
                return;

            _callbacks.Remove(callback);
        }

        public void ClearObserving()
        {
            if (_callbacks == null)
                return;

            _callbacks.Clear();
            _callbacks = null;
        }

        void IReadOnlyBindableProperty<TValue>.SetValue(
            ref TValue value,
            BindablePropertyChanged<TValue>? callbackToIgnore)
        {
            SetValue(ref value, callbackToIgnore);
        }

        public void SetValue(ref TValue value, BindablePropertyChanged<TValue>? callbackToIgnore = null)
        {
            if (RaisePropertyChanged && _callbacks is not null)
            {
                foreach (var callback in _callbacks.Where(callback => callback != callbackToIgnore))
                {
                    callback?.Invoke(_value, value);
                }
            }

            _value = value;
        }

        public void SetValueWithoutNotify(ref TValue value)
        {
            _value = value;
        }

        public bool Equals(TValue value)
        {
            return Value.Equals(value);
        }

        public override bool Equals(object obj)
        {
            return obj is BindableProperty<TValue> bindableProperty && Equals(bindableProperty);
        }

        public bool Equals(BindableProperty<TValue> other)
        {
            return EqualityComparer<TValue>.Default.Equals(_value, other._value);
        }

        // ReSharper disable once NonReadonlyMemberInGetHashCode
        public override int GetHashCode()
        {
            return EqualityComparer<TValue>.Default.GetHashCode(_value);
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public static implicit operator TValue(BindableProperty<TValue> binding)
        {
            return binding is null ? default : binding.Value;
        }
    }
}