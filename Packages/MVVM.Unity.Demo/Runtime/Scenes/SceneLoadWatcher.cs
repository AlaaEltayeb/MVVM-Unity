using MVVM.Unity.PersistentObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace MVVM.Unity.Demo.Scenes
{
    [Persistent(excludeFromReset: true)]
    public class SceneLoadWatcher : MonoBehaviour
    {
        private IPersistentObjectsSetter _persistentObjectsSetter;

        [Inject]
        public void Construct(IPersistentObjectsSetter persistentObjectsSetter)
        {
            _persistentObjectsSetter = persistentObjectsSetter;
        }

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            _persistentObjectsSetter.Initialize();
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}