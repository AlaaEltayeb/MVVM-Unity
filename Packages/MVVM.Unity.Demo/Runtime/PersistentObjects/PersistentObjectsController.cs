using MVVM.Unity.PersistentObjects;
using System.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace MVVM.Unity.Demo.PersistentObjects
{
    public class PersistentObjectsController : MonoBehaviour

    {
        [SerializeField]
        private GameObject _persistentObject;

        private IPersistentObjectsSetter _persistentObjectsSetter;

        [Inject]
        public void Construct(IPersistentObjectsSetter persistentObjectsSetter)
        {
            _persistentObjectsSetter = persistentObjectsSetter;
        }

        private void Awake()
        {
            DeletePersistentObject();
        }

        private async Task DeletePersistentObject()
        {
            var timer = 5f;
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                await Task.Yield();
            }

            var component = _persistentObject.GetComponent<PersistentObject>();
            _persistentObjectsSetter.Unregister(component);
        }

        public void CreateNewPersistentObject()
        {
            var go = new GameObject("NewPersistentObject");
            var component = go.AddComponent<PersistentObject>();
            _persistentObjectsSetter.Register(component);
        }

        public void CreateNewNonPersistentObject()
        {
            var go = new GameObject("NewNonPersistentObject");
            var component = go.AddComponent<NonPersistentObject>();
            _persistentObjectsSetter.Register(component);
        }

        public void ResetPersistentObjects()
        {
            _persistentObjectsSetter.Reset();
        }
    }
}