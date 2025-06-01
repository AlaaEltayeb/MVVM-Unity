using TMPro;
using UnityEngine;

namespace MVVM.Unity.Binding.UIBinder
{
    [RequireComponent(typeof(TMP_InputField))]
    public sealed class TMPInputFieldBinder : UIBinder<TMP_InputField, string>
    {
        protected override void OnViewModelChanged(string oldValue, string newValue)
        {
            if (UIElement.text != newValue)
                UIElement.text = newValue;
        }

        protected override void SetupUIListener()
        {
            UIElement.onValueChanged.AddListener(OnUIChanged);
        }

        private void OnUIChanged(string newValue)
        {
            if (Property.Value != newValue)
                Property.SetValue(ref newValue);
        }

        protected override void RemoveUIListner()
        {
            UIElement.onValueChanged.RemoveListener(OnUIChanged);
        }
    }
}