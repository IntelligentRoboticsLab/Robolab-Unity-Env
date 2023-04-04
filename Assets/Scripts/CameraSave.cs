using System.IO;
using UnityEngine;
 
public class CameraSave : MonoBehaviour
{

    public Camera cam;
    public int fileCounter;
    public string fileName;
    
    public void Capture()
    {
        string path = Application.dataPath + "/Captures/" + fileName + "_" + fileCounter + ".png";
        ScreenCapture.CaptureScreenshot(path, 1);
        Debug.Log("Screenshot saved to " + path);
        fileCounter++;
    }
}