using UnityEditor;
using UnityEngine;

namespace Nao.Editor
{
    [CustomEditor(typeof(NaoJointTester))]
    public class NaoJointTesterEditor:UnityEditor.Editor
    {
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            NaoJointTester myComponent = (NaoJointTester)target;

            if (GUILayout.Button("Start Test"))
            {
                myComponent.StartTest();
            }

        }
    }
}