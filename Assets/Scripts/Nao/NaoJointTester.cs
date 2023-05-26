using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaoJointTester : MonoBehaviour
{
    [SerializeField] private NaoController naoController;
    [SerializeField] private float secondsPerPart;
    private List<NaoArticulateJointController> joints;
    private NaoArticulateJointController activeJoint;
    private int runningAppliedTestPart;
    private bool running = false;
    public void StartTest()
    {
        joints = naoController.GetAllJoints();
        Debug.Log($"Start the test of {joints.Count} Joints");
        StartCoroutine(RunTest());
    }

    private IEnumerator RunTest()
    {
        foreach (var joint in joints)
        {
            yield return new WaitForSeconds(secondsPerPart);
            running = true;
            activeJoint = joint;
            Debug.Log($"Starting Forward Test of {activeJoint.GetName()}");
            activeJoint.SetExtension(1.0f);
            yield return new WaitForSeconds(secondsPerPart);
            Debug.Log($"Starting Backwards Test of {activeJoint.GetName()}");
            activeJoint.SetExtension(-1.0f);
            yield return new WaitForSeconds(secondsPerPart);
            Debug.Log($"Reset Test of {activeJoint.GetName()}");
            activeJoint.SetExtension(0f);
            yield return new WaitForSeconds(secondsPerPart);
        }

        running = false;
        runningAppliedTestPart = 0;
        Debug.Log($"Test has ended");
    }

}
