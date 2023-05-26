using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Perception.GroundTruth;

public class PerceptionToRaytracer : MonoBehaviour
{
    public PerceptionCamera perceptionCamera;
    public bool waitForRayTracer = true;

    private Camera m_camera;
    void Start()
    {
        perceptionCamera.RequestCapture();
    }
    
    void Update()
    {
       
    }
    
}
