using UnityEditor;
using UnityEngine;

namespace Nao.Editor
{
    [CustomEditor(typeof(NaoArticulateJointController))]
    public class NaoArticulateJointControllerEditor:UnityEditor.Editor
    {
        private bool locked;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            NaoArticulateJointController myComponent = (NaoArticulateJointController)target;
            if (GUILayout.Button("Apply Joint Specs"))
            {
                myComponent.ApplySpecsToArtBody();
            }
        }
    }
}