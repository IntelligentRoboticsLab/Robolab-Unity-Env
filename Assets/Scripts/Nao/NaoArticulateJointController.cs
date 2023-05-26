using Nao;
using UnityEngine;

public class NaoArticulateJointController : MonoBehaviour
{
    [SerializeField] private ArticulationBody artBody;
    [SerializeField] private JointSide side;
    [SerializeField] private JointSpecs specs;
    [SerializeField] private MotorJointSpecs motorSpecs;
    
    //SetExtension from -1 to 1
    public void SetExtension(float extend)
    {
        float target = 0;
        if (extend > 0.0f)
        {
            target = artBody.xDrive.upperLimit * Mathf.Abs(extend);
        }else if (extend < 0.0f)
        {
            target = artBody.xDrive.lowerLimit * Mathf.Abs(extend);
        }
        
        artBody.SetDriveTarget(ArticulationDriveAxis.X, target);
    }
    
    public void SetAngle(float angle)
    {
        artBody.SetDriveTarget(ArticulationDriveAxis.X, angle);
    }
    
    public float GetAngle()
    {
        var rad = artBody.jointPosition[0];
        return rad;
    }

    public string GetName()
    {
        return $"{side.ToString()} - {specs.type.ToString()}";
    }
    
    public void ApplySpecsToArtBody()
    {
        var motor = motorSpecs.GetByType(specs.motorType, specs.speedReductionType);
        artBody.mass = specs.mass;
        artBody.jointType = ArticulationJointType.RevoluteJoint;
        artBody.twistLock = ArticulationDofLock.LimitedMotion;
        artBody.automaticCenterOfMass = false;
        artBody.centerOfMass = specs.centerOfMass;
        var drive = artBody.xDrive;
        drive.lowerLimit = specs.min;
        drive.upperLimit = specs.max;
        drive.forceLimit = motor.MoveTorque;
        drive.driveType = ArticulationDriveType.Target;
        artBody.xDrive = drive;
    }
    
}
