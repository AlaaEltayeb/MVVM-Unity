using JetBrains.Annotations;
using System;

namespace MVVM.Unity.Binding
{
    public interface IMultiObservable<in TCallback> where TCallback : Delegate
    {
        void StartObserving([NotNull] TCallback callback, bool invokeOnObserve);
        void StopObserving([NotNull] TCallback callback);
        void ClearObserving();
    }
}