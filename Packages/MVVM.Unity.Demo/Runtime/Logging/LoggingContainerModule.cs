using Microsoft.Extensions.Logging;
using MVVM.Unity.Demo.DependencyInjection;
using MVVM.Unity.Demo.Extensions;
using MVVM.Unity.Logging;
using System.Collections.Generic;
using VContainer;

namespace MVVM.Unity.Demo.Logging
{
    public sealed class LoggingContainerModule : IContainerModule
    {
        public void RegisterWithBuilder(IContainerBuilder builder)
        {
            builder.Register<ILoggerProvider, UnityConsoleLoggerProvider>(Lifetime.Singleton);

            builder.Register(resolver =>
                    {
                        var providers = resolver.Resolve<IEnumerable<ILoggerProvider>>();
                        var loggerFactory = new LoggerFactory(providers);
                        return loggerFactory;
                    },
                    Lifetime.Singleton)
                .As<ILoggerFactory>();

            builder.Register(resolver =>
                    resolver.Resolve<ILoggerFactory>()
                        .CreateLogger("Unknown"),
                Lifetime.Scoped);

            builder.AddLoggersForExternalClasses();
        }
    }
}