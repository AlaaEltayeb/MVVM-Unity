#nullable enable
namespace MVVM.Unity.Binding.BindableProperty
{
    public interface IReadOnlyBindableProperty<TValue> : IMultiObservable<BindablePropertyChanged<TValue>>
    {
        TValue Value { get; }

        internal void SetValue(ref TValue value, BindablePropertyChanged<TValue>? callbackToIgnore = null);
    }
}