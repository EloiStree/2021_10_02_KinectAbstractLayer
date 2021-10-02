using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectEnumsConert : MonoBehaviour
{

    public static void Convert(in KinectSide side,in KinectBonePoint bone, out KinectBonePointLR boneLR) {
       
        switch (bone)
        {
            case KinectBonePoint.Head: boneLR= KinectBonePointLR.Head; return;
            case KinectBonePoint.Neck:
                boneLR = KinectBonePointLR.Neck; return;
            case KinectBonePoint.SpineShoulder:
                boneLR = KinectBonePointLR.SpineShoulder; return;
            case KinectBonePoint.SpineMiddle:
                boneLR = KinectBonePointLR.SpineMiddle; return;
            case KinectBonePoint.SpineBase:
                boneLR = KinectBonePointLR.SpineBase; return;

            case KinectBonePoint.Shoulder:
                boneLR = side == KinectSide.Left ? KinectBonePointLR.ShoulderLeft : KinectBonePointLR.ShoulderRight ;
                return;
            case KinectBonePoint.Elbow:
                boneLR = side == KinectSide.Left ? KinectBonePointLR.ElbowLeft : KinectBonePointLR.ElbowRight;
                break;
            case KinectBonePoint.Wrist:
                boneLR = side == KinectSide.Left ? KinectBonePointLR.WristLeft : KinectBonePointLR.WristRight;
                break;
            case KinectBonePoint.Hand:
                boneLR = side == KinectSide.Left ? KinectBonePointLR.HandLeft : KinectBonePointLR.HandRight;
                break;
            case KinectBonePoint.HandTip:
                boneLR = side == KinectSide.Left ? KinectBonePointLR.HandTipLeft : KinectBonePointLR.HandTipRight;
                break;
            case KinectBonePoint.HandThumb:
                boneLR = side == KinectSide.Left ? KinectBonePointLR.HandThumbLeft : KinectBonePointLR.HandThumbRight;
                break;
            case KinectBonePoint.Hip:
                boneLR = side == KinectSide.Left ? KinectBonePointLR.HipLeft : KinectBonePointLR.HipRight;
                break;
            case KinectBonePoint.Knee:
                boneLR = side == KinectSide.Left ? KinectBonePointLR.KneeLeft : KinectBonePointLR.KneeRight;
                break;
            case KinectBonePoint.Ankle:
                boneLR = side == KinectSide.Left ? KinectBonePointLR.AnkleLeft : KinectBonePointLR.AnkleRight;
                break;
            case KinectBonePoint.Foot:
                boneLR = side == KinectSide.Left ? KinectBonePointLR.FootLeft : KinectBonePointLR.FootRight;
                break;
            default:
                boneLR = KinectBonePointLR.Neck;
                break;
        }
    }

    public static void ConvertToArrayIndex(in KinectBonePointLR kinectBonePointLR, out short arrayIndex)
    {
        switch (kinectBonePointLR)
        {
            case KinectBonePointLR.Head:
                arrayIndex = 0;
                break;
            case KinectBonePointLR.Neck:
                arrayIndex = 1;
                break;
            case KinectBonePointLR.SpineShoulder:
                arrayIndex = 2;
                break;
            case KinectBonePointLR.SpineMiddle:
                arrayIndex = 3;
                break;
            case KinectBonePointLR.SpineBase:
                arrayIndex = 4;
                break;
            case KinectBonePointLR.ShoulderLeft:
                arrayIndex = 5;
                break;
            case KinectBonePointLR.ElbowLeft:
                arrayIndex = 6;
                break;
            case KinectBonePointLR.WristLeft:
                arrayIndex = 7;
                break;
            case KinectBonePointLR.HandLeft:
                arrayIndex = 8;
                break;
            case KinectBonePointLR.HandTipLeft:
                arrayIndex = 9;
                break;
            case KinectBonePointLR.HandThumbLeft:
                arrayIndex = 10;
                break;
            case KinectBonePointLR.ShoulderRight:
                arrayIndex = 11;
                break;
            case KinectBonePointLR.ElbowRight:
                arrayIndex = 12;
                break;
            case KinectBonePointLR.WristRight:
                arrayIndex = 13;
                break;
            case KinectBonePointLR.HandRight:
                arrayIndex = 14;
                break;
            case KinectBonePointLR.HandTipRight:
                arrayIndex = 15;
                break;
            case KinectBonePointLR.HandThumbRight:
                arrayIndex = 16;
                break;
            case KinectBonePointLR.HipLeft:
                arrayIndex = 17;
                break;
            case KinectBonePointLR.KneeLeft:
                arrayIndex = 18;
                break;
            case KinectBonePointLR.AnkleLeft:
                arrayIndex = 19;
                break;
            case KinectBonePointLR.FootLeft:
                arrayIndex = 20;
                break;
            case KinectBonePointLR.HipRight:
                arrayIndex = 21;
                break;
            case KinectBonePointLR.KneeRight:
                arrayIndex = 22;
                break;
            case KinectBonePointLR.AnkleRight:
                arrayIndex = 23;
                break;
            case KinectBonePointLR.FootRight:
                arrayIndex = 24;
                break;
            default:
                arrayIndex = 0;
                break;
        }
    }
}

public enum KinectSide { 
    Left,
    Right
}
public enum KinectBonePoint {
    Head, Neck, SpineShoulder, SpineMiddle, SpineBase,
    Shoulder, Elbow, Wrist, Hand, HandTip, HandThumb,
    Hip, Knee, Ankle, Foot
}


public enum KinectBonePointLR { 
    Head, Neck, SpineShoulder, SpineMiddle, SpineBase,
    ShoulderLeft, ElbowLeft, WristLeft, HandLeft, HandTipLeft, HandThumbLeft,
    ShoulderRight, ElbowRight, WristRight, HandRight, HandTipRight, HandThumbRight,
    HipLeft, KneeLeft, AnkleLeft, FootLeft,
    HipRight, KneeRight, AnkleRight, FootRight,
}


[System.Serializable]
public struct KinectHumanBoneConnection {
    public KinectBonePointLR m_from;
    public KinectBonePointLR m_to;
}

[System.Serializable]
public class BonesGroup {
    public KinectBonePointLR[] m_bonePoints;
}