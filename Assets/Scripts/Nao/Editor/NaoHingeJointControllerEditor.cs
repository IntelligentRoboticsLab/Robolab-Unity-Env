using UnityEditor;
using UnityEngine;

namespace Nao.Editor
{
    [CustomEditor(typeof(NaoHingeJointController))]
    public class NaoHingeJointControllerEditor:UnityEditor.Editor
    {
        private bool locked;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            NaoHingeJointController myComponent = (NaoHingeJointController)target;
            if (GUILayout.Button("Lock"))
            {
                myComponent.HoldPosition();
            }
        }
    }
}