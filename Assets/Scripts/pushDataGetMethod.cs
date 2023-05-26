using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class pushDataGetMethod : MonoBehaviour
{
    public Transform transformData;
    public float interval = 0.5f;

    private string server_address = "http://192.168.0.2/robbel/unity/g.php"; // change g.php to p.php for post method
    private UnityWebRequest webrequest;
    private float lastTime;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;
        if ((now - lastTime) > interval) {
            StartCoroutine(Upload());
            lastTime = now;
        }
    }

    IEnumerator Upload()
    {
        string message = "?x=" + transformData.position.x + "&y=" + transformData.position.y + "&z=" + transformData.position.z;

        using (webrequest = UnityWebRequest.Get(server_address + message))
        {
            // Request and wait for the desired page.
            yield return webrequest.SendWebRequest();
        }
    }
}
