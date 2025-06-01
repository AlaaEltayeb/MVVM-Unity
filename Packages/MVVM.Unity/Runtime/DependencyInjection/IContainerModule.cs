using VContainer;

namespace MVVM.Unity.DependencyInjection
{
    public interface IContainerModule
    {
        void RegisterWithBuilder(IContainerBuilder builder);
    }
}