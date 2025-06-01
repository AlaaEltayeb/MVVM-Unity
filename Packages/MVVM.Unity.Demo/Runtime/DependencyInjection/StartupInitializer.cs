using JetBrains.Annotations;
using UnityEngine;
using VContainer.Unity;

namespace MVVM.Unity.Demo.DependencyInjection
{
    /// <summary>
    /// Responsible for Bootstrapping
    /// </summary>
    [UsedImplicitly]
    public sealed class StartupInitializer : IInitializable
    {
        public void Initialize()
        {
            Debug.Log("I'm In the entry point");
        }
    }
}