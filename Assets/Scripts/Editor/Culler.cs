using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class Culler : MonoBehaviour
{
    [SerializeField]
    private float culHeight;

    public void DoCulling()
    {
        Debug.Log("Hello");
        StartCoroutine(Step());
    }

    public IEnumerator Step()
    {
        var meshes = gameObject.GetComponentsInChildren<MeshRenderer>();
        Debug.Log(meshes.Length);

        foreach (var mesh in meshes)
        {
            var mF = mesh.GetComponent<MeshFilter>();
            var mR = mesh.GetComponent<Renderer>();

            Debug.Log(mR.bounds);
            if (mR.bounds.center.y > culHeight)
            {
                Debug.Log("Test");
                DestroyImmediate(mesh.gameObject);
            }
        }
        yield return new WaitForEndOfFrame();
    }

}

[CustomEditor(typeof(Culler))]
[CanEditMultipleObjects]
public class CullerEditor : UnityEditor.Editor
{

    void OnEnable()
    {

    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var t = (target as Culler);

        if (GUILayout.Button("test"))
        {
            t.DoCulling();
            Debug.Log("Clicked the image");
        }
    }
}