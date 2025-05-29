#nullable enable
using System;
using System.Collections.Generic;

namespace MVVM.Unity.Binding.BindableCollection
{
    public sealed class BindableCollection<T> : List<T>
    {
        public event Action<T>? ItemAdded;
        public event Action<T>? ItemRemoved;
        public event Action? CollectionCleared;

        public new void Add(T item)
        {
            base.Add(item);
            ItemAdded?.Invoke(item);
        }

        public new bool Remove(T item)
        {
            var result = base.Remove(item);
            if (result)
                ItemRemoved?.Invoke(item);

            return result;
        }

        public new void Clear()
        {
            base.Clear();
            CollectionCleared?.Invoke();
        }
    }
}