using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace MVVM.Unity.Binding.BindableProperty
{
    [PublicAPI]
    public sealed class BindableProperty<TValue> : IReadOnlyBindableProperty<TValue>
    {
        private HashSet<BindablePropertyChanged<TValue>> _callbacks;

        public event Action<TValue, TValue>? ValueChanged;

        public TValue Value { get; }

        //set => SetValue(ref value);
        public bool RaisePropertyChanged { get; set; } = true;

        public BindableProperty(TValue value = default)
        {
            Value = value;
            _callbacks = null;
        }

        void IReadOnlyBindableProperty<TValue>.SetValue(
            ref TValue value,
            BindablePropertyChanged<TValue>? callbackToIgnore)
        {
            throw new NotImplementedException();
        }

        public void Bind(Action<TValue, TValue> onChanged, bool invokeImmediately = true)
        {
            ValueChanged += onChanged;

            if (invokeImmediately)
                onChanged(Value, Value);
        }

        public void Unbind(Action<TValue, TValue> onChanged)
        {
            ValueChanged -= onChanged;
        }

        public void Update(TValue newValue)
        {
            //Value = newValue;
        }

        public void StartObserving(BindablePropertyChanged<TValue> callback, bool invokeOnObserve)
        {
            throw new NotImplementedException();
        }

        public void StopObserving(BindablePropertyChanged<TValue> callback)
        {
            throw new NotImplementedException();
        }

        public void ClearObserving()
        {
            throw new NotImplementedException();
        }
    }
}