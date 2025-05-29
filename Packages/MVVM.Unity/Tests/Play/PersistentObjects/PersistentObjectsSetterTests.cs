#if UNITY_EDITOR
using MVVM.Unity.PersistentObjects;
using NSubstitute;
using NUnit.Framework;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.TestTools;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace MVVM.Unity.Play.Tests.Play.PersistentObjects
{
    public sealed class PersistentObjectsSetterTests
    {
        private GameObject _mockGameObject;
        private Component _mockComponent;

        private IPersistentObjectsSetter _mockPersistentObjectsSetter;

        private PersistentObjectsSetter _persistentObjectsSetter;

        private ILogger _logger;

        [SetUp]
        public void SetUp()
        {
            _mockGameObject = new GameObject("MockGameObject");
            _mockPersistentObjectsSetter = Substitute.For<IPersistentObjectsSetter>();

            _logger = Substitute.For<ILogger>();
            _persistentObjectsSetter = new PersistentObjectsSetter(_logger);
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_mockGameObject);
            _mockGameObject = null;
            _mockComponent = null;
            _mockPersistentObjectsSetter = null;
        }

        [Test]
        public void PersistMyself_RegistersGameObject()
        {
            _mockComponent = _mockGameObject.AddComponent<MockBehaviour>();

            _mockPersistentObjectsSetter.Register(_mockComponent);
            _mockPersistentObjectsSetter.Received(1).Register(_mockComponent);
        }

        [Test]
        public void CleanUp_UnregistersGameObject()
        {
            _mockComponent = _mockGameObject.AddComponent<MockBehaviour>();

            _mockPersistentObjectsSetter.Unregister(_mockComponent);
            _mockPersistentObjectsSetter.Received(1).Unregister(_mockComponent);
        }

        [UnityTest]
        public IEnumerator ScanForPersistentComponents_RegistersGameObjectWithPersistentAttribute()
        {
            var persistentObject = _mockGameObject.AddComponent<PersistentObject>();
            _persistentObjectsSetter.Initialize();

            yield return null;

            var registered = _persistentObjectsSetter.GetRegisteredObjects().ToList();
            Assert.Contains(_mockGameObject, registered);
        }

        private class MockBehaviour : MonoBehaviour
        {
        }

        [Persistent]
        private class PersistentObject : MonoBehaviour
        {
        }
    }
}
#endif