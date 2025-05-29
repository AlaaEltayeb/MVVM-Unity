using System.Collections.Generic;
using UnityEngine;

namespace MVVM.Unity.PersistentObjects
{
    public interface IPersistentObjectsSetter
    {
        void Initialize();
        void Register(Component component);
        void Unregister(Component component);
        void Reset();

        IReadOnlyCollection<GameObject> GetRegisteredObjects();
    }
}