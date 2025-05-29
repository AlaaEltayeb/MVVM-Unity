#if UNITY_EDITOR
using MVVM.Unity.PersistentObjects;
using System;
using UnityEditor;
using UnityEngine;

namespace MVVM.Unity.Editor.PersistentObjects
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public sealed class PersistentObjectEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var type = target.GetType();

            if (!Attribute.IsDefined(type, typeof(PersistentAttribute)))
                return;

            EditorGUILayout.HelpBox("This component is marked as persistent (DontDestroyOnLoad)", MessageType.Info);
        }
    }
}
#endif