using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NaoController : MonoBehaviour
{
    private List<NaoArticulateJointController> joints;

    void Start()
    {
        joints = GetComponentsInChildren<NaoArticulateJointController>().ToList();
    }

    public List<NaoArticulateJointController> GetAllJoints()
    {
        return joints;
    }

}
