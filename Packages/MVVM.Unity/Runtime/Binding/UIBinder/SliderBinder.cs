using UnityEngine;
using UnityEngine.UI;

namespace MVVM.Unity.Binding.UIBinder
{
    [RequireComponent(typeof(Slider))]
    public sealed class SliderBinder : UIBinder<Slider, float>
    {
        protected override void OnViewModelChanged(float oldValue, float newValue)
        {
            if (!Mathf.Approximately(UIElement.value, newValue))
                UIElement.value = newValue;
        }

        protected override void SetupUIListener()
        {
            UIElement.onValueChanged.AddListener(OnUIChanged);
        }

        private void OnUIChanged(float newValue)
        {
            //if (!Mathf.Approximately(Property.Value, newValue))
            //    Property.SetValue(ref newValue);
        }

        protected override void RemoveUIListner()
        {
            UIElement.onValueChanged.RemoveListener(OnUIChanged);
        }
    }
}