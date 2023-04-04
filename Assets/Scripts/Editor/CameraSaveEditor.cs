using UnityEditor;
using UnityEngine;

namespace Editor
{
    
    [CustomEditor(typeof(CameraSave))]
    public class CameraSaveEditor:UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            var m_target = target as CameraSave;

            if (GUILayout.Button("Capture"))
            {
                m_target.Capture();
            }
            
        }
    }
}