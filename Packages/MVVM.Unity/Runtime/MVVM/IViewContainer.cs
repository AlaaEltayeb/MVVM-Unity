using UnityEngine;

namespace MVVM.Unity.MVVM
{
    public interface IViewContainer
    {
        GameObject GetView<TView>();
    }
}