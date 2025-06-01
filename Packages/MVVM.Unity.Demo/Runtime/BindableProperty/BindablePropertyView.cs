using MVVM.Unity.Binding.UIBinder;
using MVVM.Unity.MVVM;
using TMPro;
using UnityEngine;

namespace MVVM.Unity.Demo.BindableProperty
{
    public class BindablePropertyView : ViewBase<BindablePropertyViewModel>
    {
        [SerializeField]
        private TextMeshProUGUI _nameText;

        [SerializeField]
        private TMPInputFieldBinder _nameInputFieldBinder;

        protected override void Bind()
        {
            ViewModel.NameProperty.StartObserving(OnNameChanged, false);
            //_nameInputFieldBinder.Property = ViewModel.NameProperty;
            _nameInputFieldBinder.Bind(OnInputFieldChanged);
        }

        private void OnInputFieldChanged(string value)
        {
            ViewModel.OnNameInputChanged(value);
        }

        private void OnNameChanged(string oldValue, string newValue)
        {
            _nameText.text = newValue;
        }
    }
}