using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KinectDebugLogDrawLineUpdate : MonoBehaviour
{
    public KinectAvatarPositionAsVector3 m_source;

    public float m_cartesianLineSize = 0.1f;
    public KinectBonePointLR m_rootToBone;
    public Color m_rootToBoneColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float td = Time.deltaTime;
        KinectDrawing.DrawLineCartesian(in m_source.m_source.m_avatarInfo.m_kinectRoot, in m_cartesianLineSize, in td);
        KinectDrawing.RootToBone(in m_source.m_source.m_avatarInfo.m_kinectRoot, in m_source.m_worldPosition, in m_rootToBone,in m_rootToBoneColor, in td);
        KinectDrawing.DrawLinesOfWorldVector3Bones(in m_source, in td);
        
    }
}


public class KinectDrawing {

    public static void DrawLinesOfWorldVector3Bones(in KinectAvatarPositionAsVector3 avatarTransform,in float timeInSeconds) {

        KinectSide kinectSide;
        Color c = Color.yellow;
        BonesArrayVector3 worldPoint = avatarTransform.m_worldPosition;
        DrawLinesOfWorldVector3Bones(in worldPoint, in KinectUtility.m_leftArm, in c, in timeInSeconds);
        DrawLinesOfWorldVector3Bones(in worldPoint, in KinectUtility.m_rightArm, in c, in timeInSeconds);
        DrawLinesOfWorldVector3Bones(in worldPoint, in KinectUtility.m_leftLeg, in c, in timeInSeconds);
        DrawLinesOfWorldVector3Bones(in worldPoint, in KinectUtility.m_rightLeg, in c, in timeInSeconds);
        c = Color.green;
        // DrawLinesOfWorldVector3Bones(in worldPoint, in KinectUtility.m_body, in c, in timeInSeconds);
        DrawLinesOfBodyAsSquare(in worldPoint, in c, in timeInSeconds);
        c = Color.green*0.5f;
        DrawLinesOfBodyAsCross(in worldPoint, in c, in timeInSeconds);
        c = Color.red;
        DrawLinesOfWorldVector3Bones(in worldPoint, in KinectUtility.m_spine, in c, in timeInSeconds);
        kinectSide = KinectSide.Left;
        c = Color.red;
        DrawLinesOfHand(in worldPoint, in kinectSide, in c, in timeInSeconds);
        kinectSide = KinectSide.Right;
        c = Color.red;
        DrawLinesOfHand(in worldPoint, in kinectSide, in c, in timeInSeconds);

    }

    private static void DrawLinesOfHand(in BonesArrayVector3 worldPoint, in KinectSide left, in Color c, in float timeInSeconds)
    {

        KinectBonePointLR from, to;
        from = left== KinectSide.Left? KinectBonePointLR.HandTipLeft: KinectBonePointLR.HandTipRight;
        to = left == KinectSide.Left ? KinectBonePointLR.HandLeft: KinectBonePointLR.HandRight;
        DrawLine(in worldPoint, in from, in to, in c, in timeInSeconds);
        from = left == KinectSide.Left ? KinectBonePointLR.WristLeft: KinectBonePointLR.WristRight;
        to = left == KinectSide.Left ? KinectBonePointLR.HandLeft: KinectBonePointLR.HandRight;
        DrawLine(in worldPoint, in from, in to, in c, in timeInSeconds);
        from = left == KinectSide.Left ? KinectBonePointLR.HandLeft: KinectBonePointLR.HandRight;
        to = left == KinectSide.Left ? KinectBonePointLR.HandThumbLeft: KinectBonePointLR.HandThumbRight;
        DrawLine(in worldPoint, in from, in to, in c, in timeInSeconds);
    }

    private static void DrawLinesOfBodyAsCross(in BonesArrayVector3 worldPoint, in Color c, in float timeInSeconds)
    {
        KinectBonePointLR from, to;
        from = KinectBonePointLR.ShoulderLeft;
        to = KinectBonePointLR.HipRight;
        DrawLine(in worldPoint, in from, in to, in c, in timeInSeconds);
        from = KinectBonePointLR.ShoulderRight;
        to = KinectBonePointLR.HipLeft;
        DrawLine(in worldPoint, in from, in to, in c, in timeInSeconds);

    }

    private static void DrawLinesOfBodyAsSquare(in BonesArrayVector3 worldPoint, in Color c, in float timeInSeconds)
    {
        KinectBonePointLR from, to;
        from = KinectBonePointLR.ShoulderLeft;
        to = KinectBonePointLR.ShoulderRight;
        DrawLine(in worldPoint, in from, in to, in c, in timeInSeconds);
        from = KinectBonePointLR.ShoulderLeft;
        to = KinectBonePointLR.HipLeft;
        DrawLine(in worldPoint, in from, in to, in c, in timeInSeconds);
        from = KinectBonePointLR.ShoulderRight;
        to = KinectBonePointLR.HipRight;
        DrawLine(in worldPoint, in from, in to, in c, in timeInSeconds);
        from = KinectBonePointLR.HipLeft;
        to = KinectBonePointLR.HipRight;
        DrawLine(in worldPoint, in from, in to, in c, in timeInSeconds);

    }

    public static void DrawLinesOfWorldVector3Bones(in BonesArrayVector3 source, in KinectBonePointLR[] bones, in Color color, in float timeInSeconds) {

        if (bones.Count() < 2) return;
        KinectBonePointLR previous = KinectBonePointLR.Head; 
        KinectBonePointLR current = KinectBonePointLR.Head;
        Vector3 worldPositionPrevious= Vector3.zero;
        Vector3 worldPositionCurrent = Vector3.zero;
        int i = 0;
        foreach (KinectBonePointLR item in bones)
        {
            previous = current;
            current = item;
            if (i > 0)
            {
                source.Get(in previous, out worldPositionPrevious);
                source.Get(in current, out worldPositionCurrent);
                Debug.DrawLine(worldPositionPrevious, worldPositionCurrent, color, timeInSeconds);
            }
            i++;
        }
    }

    public static void DrawLine(in BonesArrayVector3 source, in KinectBonePointLR from, in  KinectBonePointLR to, in Color color, in float timeInSeconds) {

        Vector3 vFrom = Vector3.zero;
        Vector3 vTo = Vector3.zero;
        source.Get(in from, out vFrom);
        source.Get(in to, out vTo);
        Debug.DrawLine(vFrom, vTo, color, timeInSeconds);
    }

    public static void DrawLineCartesian(in Transform kinectRoot, in float lineSize, in float time)
    {
        Debug.DrawLine(kinectRoot.position, kinectRoot.forward * lineSize, Color.blue, time);
        Debug.DrawLine(kinectRoot.position, kinectRoot.up * lineSize, Color.green, time);
        Debug.DrawLine(kinectRoot.position, kinectRoot.right * lineSize, Color.red, time);
    }

    public static void RootToBone(in Vector3 kinectRoot, in BonesArrayVector3 source, in KinectBonePointLR rootToBone, in Color color, in float time)
    {
        source.Get(in rootToBone, out Vector3 position);
        Debug.DrawLine(kinectRoot, position, color, time);
    }

    public static void RootToBone(in Transform kinectRoot, in BonesArrayVector3 source, in KinectBonePointLR rootToBone, in Color color, in float time)
    {
        Vector3 p = kinectRoot.position;
        RootToBone(in p,in source, in rootToBone, in color, in time);
    }
}

public static class KinectUtility
{
    public  static readonly KinectBonePointLR[] m_leftArm = new KinectBonePointLR[] { KinectBonePointLR.ShoulderLeft, KinectBonePointLR.ElbowLeft, KinectBonePointLR.WristLeft , KinectBonePointLR.HandLeft};
    public static readonly KinectBonePointLR[] m_rightArm= new KinectBonePointLR[] { KinectBonePointLR.ShoulderRight, KinectBonePointLR.ElbowRight, KinectBonePointLR.WristRight, KinectBonePointLR.HandRight };
    public static readonly KinectBonePointLR[] m_leftLeg = new KinectBonePointLR[] { KinectBonePointLR.HipLeft, KinectBonePointLR.KneeLeft, KinectBonePointLR.AnkleLeft, KinectBonePointLR.FootLeft };
    public static readonly KinectBonePointLR[] m_rightLeg = new KinectBonePointLR[] { KinectBonePointLR.HipRight, KinectBonePointLR.KneeRight, KinectBonePointLR.AnkleRight, KinectBonePointLR.FootRight };
    public static readonly KinectBonePointLR[] m_body = new KinectBonePointLR[] { KinectBonePointLR.ShoulderLeft, KinectBonePointLR.ShoulderRight, KinectBonePointLR.HipLeft, KinectBonePointLR.HipRight };
    public static readonly KinectBonePointLR[] m_spine = new KinectBonePointLR[] { KinectBonePointLR.Head, KinectBonePointLR.Neck, KinectBonePointLR.SpineShoulder, KinectBonePointLR.SpineMiddle, KinectBonePointLR.SpineBase };
    public static readonly KinectBonePointLR[] m_head = new KinectBonePointLR[] { KinectBonePointLR.Head, KinectBonePointLR.Neck };
    public static readonly KinectBonePointLR[] m_allBonesPoints = new KinectBonePointLR[] { KinectBonePointLR.Head,  KinectBonePointLR.Neck,  KinectBonePointLR.SpineShoulder,  KinectBonePointLR.SpineMiddle, KinectBonePointLR. SpineBase,
     KinectBonePointLR.ShoulderLeft,  KinectBonePointLR.ElbowLeft,  KinectBonePointLR.WristLeft,  KinectBonePointLR.HandLeft, KinectBonePointLR. HandTipLeft, KinectBonePointLR. HandThumbLeft,
    KinectBonePointLR. ShoulderRight, KinectBonePointLR. ElbowRight,  KinectBonePointLR.WristRight, KinectBonePointLR. HandRight,  KinectBonePointLR.HandTipRight, KinectBonePointLR. HandThumbRight,
     KinectBonePointLR.HipLeft,  KinectBonePointLR.KneeLeft, KinectBonePointLR. AnkleLeft,  KinectBonePointLR.FootLeft,
     KinectBonePointLR.HipRight, KinectBonePointLR. KneeRight,  KinectBonePointLR.AnkleRight,  KinectBonePointLR.FootRight };

    public static readonly DualKinectBone m_shoulders = new DualKinectBone() { m_a = KinectBonePointLR.ShoulderLeft, m_b =KinectBonePointLR.ShoulderRight };
    public static readonly DualKinectBone m_hips = new DualKinectBone() { m_a = KinectBonePointLR.HipLeft, m_b = KinectBonePointLR.HipRight };
    public static readonly DualKinectBone m_hands = new DualKinectBone() { m_a = KinectBonePointLR.HandLeft, m_b = KinectBonePointLR.HandRight };
    public static readonly DualKinectBone m_feet = new DualKinectBone() { m_a = KinectBonePointLR.FootLeft, m_b = KinectBonePointLR.FootRight };

    public static void GetAllBones(out KinectBonePointLR[] bones)
    {
        bones= m_allBonesPoints;
    }

    public static void ConvertLocalToWorld(in Transform m_usedRootTransform,
       in  Vector3 frontalLocalPosition,
        out Vector3 worldPoint)
    {
        Vector3 p = m_usedRootTransform.position;
        Quaternion r= m_usedRootTransform.rotation;
        ConvertLocalToWorld(in p, in r,
             in frontalLocalPosition, out worldPoint);
    }
    public static void ConvertLocalToWorld(in Vector3 positionRoot,
        in Quaternion rotationRoot,
     in Vector3 localPoint,
     out Vector3 worldPoint)
    {
        worldPoint = (rotationRoot * localPoint) + positionRoot;
    }
}

[System.Serializable]
public struct DualKinectBone
{
    public KinectBonePointLR m_a;
    public KinectBonePointLR m_b;
}