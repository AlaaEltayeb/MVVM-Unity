using UnityEngine;
using UnityEngine.UI;

namespace MVVM.Unity.Binding.UIBinder
{
    [RequireComponent(typeof(InputField))]
    public sealed class InputFieldBinder : UIBinder<InputField, string>
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
            //if (Property.Value != newValue)
            //    Property.SetValue(ref newValue);

            foreach (var callback in Callbacks)
            {
                callback?.Invoke(newValue);
            }
        }

        protected override void RemoveUIListner()
        {
            UIElement.onValueChanged.RemoveListener(OnUIChanged);
        }
    }
}