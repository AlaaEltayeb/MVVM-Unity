using Microsoft.Extensions.Logging;
using VContainer;

namespace MVVM.Unity.DependencyInjection.Extensions
{
    public static class VContainerBuilderExtension
    {
        public static void AddLoggersForExternalClasses(this IContainerBuilder self)
        {
        }

        public static void AddLogger<T>(this IContainerBuilder self) where T : class
        {
            self.Register(resolver => resolver
                    .Resolve<ILoggerFactory>()
                    .CreateLogger<T>(),
                Lifetime.Scoped);
        }

        public static IContainerBuilder AddModule(
            this IContainerBuilder container,
            IContainerModule module)
        {
            module.RegisterWithBuilder(container);
            return container;
        }

        public static IContainerBuilder AddModules(
            this IContainerBuilder container,
            params IContainerModule[] modules)
        {
            foreach (var module in modules)
            {
                container.AddModule(module);
            }

            return container;
        }
    }
}