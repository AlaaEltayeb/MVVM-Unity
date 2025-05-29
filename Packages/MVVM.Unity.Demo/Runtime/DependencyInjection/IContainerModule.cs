using VContainer;

namespace MVVM.Unity.Demo.DependencyInjection
{
    public interface IContainerModule
    {
        void RegisterWithBuilder(IContainerBuilder builder);
    }
}