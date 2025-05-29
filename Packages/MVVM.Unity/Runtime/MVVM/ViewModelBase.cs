using JetBrains.Annotations;

namespace MVVM.Unity.MVVM
{
    [PublicAPI]
    public abstract class ViewModelBase : IViewModel
    {
        public virtual void Dispose()
        {
        }
    }
}