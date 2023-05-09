using Nao;
using UnityEngine;

[CreateAssetMenu(fileName = "JointSpecs", menuName = "Nao/JointSpecs")]
public class JointSpecs : ScriptableObject
{
    public JointType type;
    public MotorTypes motorType;
    public SpeedReductionType speedReductionType;
    public float mass;
    public Vector3 centerOfMass;
    public float min;
    public float max;
}
