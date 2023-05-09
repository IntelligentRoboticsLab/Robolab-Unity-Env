using System;
using System.Collections;
using Nao;
using UnityEngine;

public class NaoHingeJointController : MonoBehaviour
{
    [SerializeField] private JointType type;
    [SerializeField] private JointSide side;
    [SerializeField] private bool horizontalKeyboardControl;
    [SerializeField] private bool verticalKeyboardControl;

    [SerializeField] private HingeJoint joint;
    [SerializeField] private Rigidbody rigid;
    
    [Tooltip("center of Mass in meters")]
    [SerializeField] private Vector3 centerOfMass;

    [SerializeField] private MotorJointSpecs motorJointSpecs;
    [SerializeField] private MotorTypes motorType;
    [SerializeField] private SpeedReductionType reductionType;
    [SerializeField] private float movementDirection = 1.0f;
    
    private MotorSpecs specs;
    
    private void Start()
    {
        rigid.centerOfMass = centerOfMass;
        Debug.Log(motorJointSpecs);
        specs = motorJointSpecs.GetByType(motorType, reductionType);
        StartCoroutine(HoldPosition());
    }

    void Update()
    {
        if (horizontalKeyboardControl)
        { 
            SetMotor(Input.GetAxisRaw("Horizontal"));
        }
        if (verticalKeyboardControl)
        { 
            SetMotor(Input.GetAxisRaw("Vertical"));
        }
    }
    //BE AWARE of the mechanic of locking a joint with springs
    public void SetMotor(float direction)
    {
        if (direction == 0) return; 
        joint.useMotor = true;
        joint.useSpring = false;
        var motor = joint.motor;
        motor.targetVelocity = specs.Speed * direction * movementDirection;
        motor.force = specs.MoveTorque;
        joint.motor = motor;
        StartCoroutine(HoldPosition());
    }

    public IEnumerator HoldPosition()
    {
        yield return new WaitForFixedUpdate();
        var springJoint = joint.spring;
        springJoint.spring = specs.StallTorque;
        springJoint.damper = 0f;
        springJoint.targetPosition = joint.angle;
        // Set the target position to the current position
        joint.useMotor = false;
        joint.useSpring = true;
        joint.spring = springJoint;
    }

    public string GetName()
    {
        return $"{side.ToString()} - {type.ToString()}";
    }

    public void SetHingeJoint(HingeJoint hingeJoint)
    {
        joint = hingeJoint;
    }
    
    public void SetRigidBody(Rigidbody rig)
    {
        rigid = rig;
    }
    
}
