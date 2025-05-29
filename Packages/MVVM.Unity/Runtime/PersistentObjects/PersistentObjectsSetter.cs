using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Object = UnityEngine.Object;

namespace MVVM.Unity.PersistentObjects
{
    public sealed class PersistentObjectsSetter : IPersistentObjectsSetter, IDisposable
    {
        private readonly HashSet<int> _persistentObjectIds = new();
        private readonly HashSet<GameObject> _trackedObjects = new();
        private readonly ILogger _logger;

        public IReadOnlyCollection<GameObject> GetRegisteredObjects()
        {
            return _trackedObjects.ToList().AsReadOnly();
        }

        public PersistentObjectsSetter(ILogger logger)
        {
            _logger = logger;
        }

        public void Initialize()
        {
            ScanForPersistentComponents();
        }

        public void Register(Component component)
        {
            TryMakePersist(component);
        }

        public void Unregister(Component component)
        {
            if (component == null)
                return;

            var go = component.gameObject;
            var id = go.GetInstanceID();

            if (_persistentObjectIds.Remove(id))
            {
                Object.DestroyImmediate(go);
                _logger.LogInformation($"[Persistence] Unregistered and destroyed: {go.name}");
            }
            else
            {
                _logger.LogWarning($"[Persistence] Attempted to unregister non-persistent object: {go.name}");
            }
        }

        private void ScanForPersistentComponents()
        {
            var components = Object.FindObjectsByType<MonoBehaviour>(sortMode: FindObjectsSortMode.None);

            foreach (var component in components)
                TryMakePersist(component);
        }

        private void TryMakePersist(Component component)
        {
            var type = component.GetType();

            var attribute = (PersistentAttribute)Attribute.GetCustomAttribute(type, typeof(PersistentAttribute));
            if (attribute == null)
                return;

            var go = component.gameObject;
            var id = go.GetInstanceID();

            if (_persistentObjectIds.Contains(id))
                return;

            Object.DontDestroyOnLoad(go);

            _persistentObjectIds.Add(id);

            if (attribute.ExcludeFromReset)
                return;

            _trackedObjects.Add(go);

            _logger.LogInformation($"[Persistence] {type.Name} made persistent via DontDestroyOnLoad.");
        }

        public void Reset()
        {
            foreach (var go in _trackedObjects.Where(go => go != null))
            {
                Object.DestroyImmediate(go);
                var id = go.GetInstanceID();
                _persistentObjectIds.Remove(id);
            }

            _trackedObjects.Clear();
        }

        public void Dispose()
        {
            Reset();
        }
    }
}