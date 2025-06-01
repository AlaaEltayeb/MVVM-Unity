using MVVM.Unity.Binding.BindableProperty;
using MVVM.Unity.MVVM;

namespace MVVM.Unity.Demo.BindableProperty
{
    public class BindablePropertyViewModel : ViewModelBase
    {
        private readonly BindableProperty<string> _nameProperty = new();

        public IReadOnlyBindableProperty<string> NameProperty => _nameProperty;

        public BindablePropertyViewModel()
        {
            _nameProperty.Value = "Default Name";
        }

        public void OnNameInputChanged(string value)
        {
            _nameProperty.Value = value;
        }
    }
}