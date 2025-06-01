using MVVM.Unity.Binding.BindableProperty;
using MVVM.Unity.MVVM;

namespace MVVM.Unity.Demo.BindableProperty
{
    public class BindablePropertyViewModel : ViewModelBase
    {
        public BindableProperty<string> NameProperty { get; set; } = new();

        public BindablePropertyViewModel()
        {
            NameProperty.Value = "Default Name";
        }
    }
}