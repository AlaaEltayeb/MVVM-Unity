using System;

namespace MVVM.Unity.MVVM
{
    public interface IView : IDisposable
    {
        IViewModel GetViewModel();
    }
}