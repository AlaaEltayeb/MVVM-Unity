#nullable enable
using MVVM.Unity.Binding.BindableProperty;
using UnityEngine;

namespace MVVM.Unity.Binding.UIBinder
{
    public abstract class UIBinder<TUI, TValue> : MonoBehaviour where TUI : Component
    {
        public BindableProperty<TValue>? Property;
        protected TUI UIElement;

        protected virtual void Awake()
        {
            UIElement = GetComponent<TUI>();
        }

        protected virtual void Start()
        {
            if (Property == null)
                return;

            Property.StartObserving(OnViewModelChanged);
            SetupUIListener();
        }

        protected virtual void OnDestroy()
        {
            if (Property == null)
                return;

            Property.StopObserving(OnViewModelChanged);
            RemoveUIListner();
        }

        protected abstract void OnViewModelChanged(TValue oldValue, TValue newValue);
        protected abstract void SetupUIListener();
        protected abstract void RemoveUIListner();
    }
}