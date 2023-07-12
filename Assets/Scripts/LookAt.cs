using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position + new Vector3(0.0f, 3.0f, 0.0f));
    }
}
