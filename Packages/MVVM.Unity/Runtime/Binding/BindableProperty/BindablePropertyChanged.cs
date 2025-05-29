namespace MVVM.Unity.Binding.BindableProperty
{
    public delegate void BindablePropertyChanged<in TValue>(
        TValue oldValue,
        TValue newValue);
}