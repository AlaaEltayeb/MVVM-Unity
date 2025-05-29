using UnityEngine;

namespace MVVM.Unity.MVVM
{
    public interface IViewFactory
    {
        IView Create<TView>(
            string name,
            Transform parent = null)
            where TView : IView;
    }
}