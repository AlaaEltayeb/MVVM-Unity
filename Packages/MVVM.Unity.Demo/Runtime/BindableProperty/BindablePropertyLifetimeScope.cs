using MVVM.Unity.DependencyInjection.Extensions;
using MVVM.Unity.Logging;
using MVVM.Unity.MVVM;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MVVM.Unity.Demo.BindableProperty
{
    public class BindablePropertyLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private ViewContainer _viewContainer;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.AddModules(
                new LoggingContainerModule());

            builder.RegisterInstance<IViewContainer>(_viewContainer);

            builder.Register<IViewFactory, ViewFactory>(Lifetime.Singleton);
            builder.RegisterComponentsInHierarchy<BindablePropertyView, BindablePropertyViewModel>(Lifetime.Scoped);
        }
    }
}