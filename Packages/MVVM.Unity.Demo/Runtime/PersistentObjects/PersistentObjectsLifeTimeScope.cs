using MVVM.Unity.DependencyInjection.Extensions;
using MVVM.Unity.Logging;
using MVVM.Unity.PersistentObjects;
using VContainer;
using VContainer.Unity;

namespace MVVM.Unity.Demo.PersistentObjects
{
    [Persistent(excludeFromReset: true)]
    public class PersistentObjectsLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.AddModules(
                new LoggingContainerModule());

            builder.Register<IPersistentObjectsSetter, PersistentObjectsSetter>(Lifetime.Singleton);
        }
    }
}