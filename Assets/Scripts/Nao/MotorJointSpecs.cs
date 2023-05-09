using UnityEngine;

public enum MotorTypes
{
    Type1,
    Type2,
    Type3,
    Type4
}

public enum SpeedReductionType
{
    A,
    B
}

public struct MotorSpecs
{
    public float Speed;
    public float StallTorque;
    public float MoveTorque;
    public float SpeedReduction;
}

[CreateAssetMenu(fileName = "MotorJointSpecs", menuName = "Nao/MotorJointSpecs")]
public class MotorJointSpecs : ScriptableObject
{
    public float type1Speed;
    public float type1StallTorque;
    public float type1MoveTorque;
    public float type1SpeedReductionA;
    public float type1SpeedReductionB;
    
    public float type2Speed;
    public float type2StallTorque;
    public float type2MoveTorque;
    public float type2SpeedReductionA;
    public float type2SpeedReductionB;
    
    public float type3Speed;
    public float type3StallTorque;
    public float type3MoveTorque;
    public float type3SpeedReductionA;
    public float type3SpeedReductionB;
    
    public float type4Speed;
    public float type4StallTorque;
    public float type4MoveTorque;
    public float type4SpeedReductionA;
    public float type4SpeedReductionB;
    
    private float rpmToDeg = 6; //Convert rpm to deg/sec by multiplying it by 6 
    private float nmnToN = 1000; //Convert from mNm to N by dividing by 1000
    public MotorSpecs GetByType(MotorTypes type, SpeedReductionType speedReductionType)
    {
        MotorSpecs result = new MotorSpecs();
        float reduction;
        switch (type)
        {
            case MotorTypes.Type1:
                reduction = speedReductionType == SpeedReductionType.A
                    ? type1SpeedReductionA
                    : type1SpeedReductionB;
                result.Speed = type1Speed * rpmToDeg / reduction;
                result.StallTorque = type1StallTorque / nmnToN * reduction;
                result.MoveTorque = type1MoveTorque / nmnToN * reduction;
                break;
            case MotorTypes.Type2:
                reduction = speedReductionType == SpeedReductionType.A
                    ? type2SpeedReductionA
                    : type2SpeedReductionB;
                result.Speed = type2Speed * rpmToDeg / reduction;
                result.StallTorque = type2StallTorque / nmnToN * reduction;
                result.MoveTorque = type2MoveTorque / nmnToN * reduction;
                break;
            case MotorTypes.Type3:
                reduction = speedReductionType == SpeedReductionType.A
                    ? type3SpeedReductionA
                    : type3SpeedReductionB;
                result.Speed = type3Speed * rpmToDeg / reduction;
                result.StallTorque = type3StallTorque / nmnToN * reduction;
                result.MoveTorque = type3MoveTorque / nmnToN * reduction;
                break;
            case MotorTypes.Type4:
                reduction = speedReductionType == SpeedReductionType.A
                    ? type4SpeedReductionA
                    : type4SpeedReductionB;
                result.Speed = type4Speed * rpmToDeg / reduction;
                result.StallTorque = type4StallTorque / nmnToN * reduction;
                result.MoveTorque = type4MoveTorque / nmnToN * reduction;
                break;
        }

        return result;
    }
}