using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class KinectAvatarTagManagerMono : MonoBehaviour
{

    public KinectTransformPoint m_avatarInfo;

    [ContextMenu("Auto Fill with avatar container")]
    public void AutoFillWithTagMonoInGameObject()
    {
        if (m_avatarInfo.m_avatarContainer != null)
            AutoFillWithTagMonoInGameObject(m_avatarInfo.m_avatarContainer.gameObject);
        else if (m_avatarInfo.m_kinectRoot != null)
            AutoFillWithTagMonoInGameObject(m_avatarInfo.m_kinectRoot.gameObject);

    }
    
        public void AutoFillWithTagMonoInGameObject(GameObject searchIn) {
        KinectBoneTagMono [] tags= searchIn.GetComponentsInChildren<KinectBoneTagMono>();
        for (int i = 0; i < tags.Length; i++)
        {
            KinectBonePointLR point = tags[i].m_kinectPoint;
            Transform anchor = tags[i].GetLinkedTransform();
            m_avatarInfo.SetOverride(in point, in anchor);
        }

    }

    public void GetTransformOf(in KinectBonePointLR pointType, out Transform point)
    {
        switch (pointType)
        {
            case KinectBonePointLR.Head:
                point = m_avatarInfo.m_head;
                break;
            case KinectBonePointLR.Neck:
                point = m_avatarInfo.m_head;
                break;
            case KinectBonePointLR.SpineShoulder:
                point = m_avatarInfo.m_spineShoulder;
                break;
            case KinectBonePointLR.SpineMiddle:
                point = m_avatarInfo.m_spineMiddle;
                break;
            case KinectBonePointLR.SpineBase:
                point = m_avatarInfo.m_spineBase;
                break;
            case KinectBonePointLR.ShoulderLeft:
                point = m_avatarInfo.m_shoulderLeft;
                break;
            case KinectBonePointLR.ElbowLeft:
                point = m_avatarInfo.m_elbowLeft;
                break;
            case KinectBonePointLR.WristLeft:
                point = m_avatarInfo.m_wristLeft;
                break;
            case KinectBonePointLR.HandLeft:
                point = m_avatarInfo.m_handLeft;
                break;
            case KinectBonePointLR.HandTipLeft:
                point = m_avatarInfo.m_handTipLeft;
                break;
            case KinectBonePointLR.HandThumbLeft:
                point = m_avatarInfo.m_handThumbLeft;
                break;
            case KinectBonePointLR.ShoulderRight:
                point = m_avatarInfo.m_shoulderRight;
                break;
            case KinectBonePointLR.ElbowRight:
                point = m_avatarInfo.m_elbowRight;
                break;
            case KinectBonePointLR.WristRight:
                point = m_avatarInfo.m_wristRight;
                break;
            case KinectBonePointLR.HandRight:
                point = m_avatarInfo.m_handRight;
                break;
            case KinectBonePointLR.HandTipRight:
                point = m_avatarInfo.m_handTipRight;
                break;
            case KinectBonePointLR.HandThumbRight:
                point = m_avatarInfo.m_handThumbRight;
                break;
            case KinectBonePointLR.HipLeft:
                point = m_avatarInfo.m_hipLeft;
                break;
            case KinectBonePointLR.KneeLeft:
                point = m_avatarInfo.m_kneeLeft;
                break;
            case KinectBonePointLR.AnkleLeft:
                point = m_avatarInfo.m_ankleLeft;
                break;
            case KinectBonePointLR.FootLeft:
                point = m_avatarInfo.m_footLeft;
                break;
            case KinectBonePointLR.HipRight:
                point = m_avatarInfo.m_hipRight;
                break;
            case KinectBonePointLR.KneeRight:
                point = m_avatarInfo.m_kneeRight;
                break;
            case KinectBonePointLR.AnkleRight:
                point = m_avatarInfo.m_ankleRight;
                break;
            case KinectBonePointLR.FootRight:
                point = m_avatarInfo.m_footRight;
                break;
            default:
                point = null;
                break;
        }
    }
    public void GetTransformOf(in KinectSide side, in KinectBonePoint bone, out Transform point)
    {
        KinectEnumsConert.Convert(side, bone, out KinectBonePointLR boneLR);
        GetTransformOf(in boneLR, out point);

        KinectEnumsConert.ConvertToArrayIndex( boneLR, out short arrayIndex);
    }
}

[System.Serializable]
public struct KinectTransformPoint {
    public Transform m_kinectRoot;
    public Transform m_avatarContainer;
    public Transform m_head;
    public Transform m_neck;
    public Transform m_spineShoulder;
    public Transform m_spineMiddle;
    public Transform m_spineBase;
    public Transform m_shoulderLeft;
    public Transform m_elbowLeft;
    public Transform m_wristLeft;
    public Transform m_handLeft;
    public Transform m_handTipLeft;
    public Transform m_handThumbLeft;
    public Transform m_shoulderRight;
    public Transform m_elbowRight;
    public Transform m_wristRight;
    public Transform m_handRight;
    public Transform m_handTipRight;
    public Transform m_handThumbRight;
    public Transform m_hipLeft;
    public Transform m_kneeLeft;
    public Transform m_ankleLeft;
    public Transform m_footLeft;
    public Transform m_hipRight;
    public Transform m_kneeRight;
    public Transform m_ankleRight;
    public Transform m_footRight;

    public void SetOverride(in KinectBonePointLR point, in Transform anchor)
    {
        switch (point)
        {
            case KinectBonePointLR.Head:   m_head = anchor; break;
            case KinectBonePointLR.Neck:  m_neck = anchor; break;
            case KinectBonePointLR.SpineShoulder:  m_spineShoulder = anchor; break;
            case KinectBonePointLR.SpineMiddle:  m_spineMiddle = anchor; break;
            case KinectBonePointLR.SpineBase:  m_spineBase = anchor; break;
            case KinectBonePointLR.ShoulderLeft:  m_shoulderLeft = anchor; break;
            case KinectBonePointLR.ElbowLeft:  m_elbowLeft = anchor; break;
            case KinectBonePointLR.WristLeft:  m_wristLeft = anchor; break;
            case KinectBonePointLR.HandLeft:  m_handLeft = anchor; break;
            case KinectBonePointLR.HandTipLeft:  m_handTipLeft = anchor; break;
            case KinectBonePointLR.HandThumbLeft: m_handThumbLeft = anchor; break;
            case KinectBonePointLR.ShoulderRight:   m_shoulderRight = anchor; break;
            case KinectBonePointLR.ElbowRight:   m_elbowRight = anchor; break;
            case KinectBonePointLR.WristRight:  m_wristRight = anchor; break;
            case KinectBonePointLR.HandRight:   m_handRight = anchor; break;
            case KinectBonePointLR.HandTipRight:  m_handTipRight = anchor; break;
            case KinectBonePointLR.HandThumbRight:  m_handThumbRight = anchor; break;
            case KinectBonePointLR.HipLeft:   m_hipLeft = anchor; break;
            case KinectBonePointLR.KneeLeft:   m_kneeLeft = anchor; break;
            case KinectBonePointLR.AnkleLeft:   m_ankleLeft = anchor; break;
            case KinectBonePointLR.FootLeft:   m_footLeft = anchor; break;
            case KinectBonePointLR.HipRight:   m_hipRight = anchor; break;
            case KinectBonePointLR.KneeRight:   m_kneeRight = anchor; break;
            case KinectBonePointLR.AnkleRight:  m_ankleRight = anchor; break;
            case KinectBonePointLR.FootRight:   m_footRight = anchor; break;
            default:
                break;
        }
    }
    public void Get(in KinectBonePointLR point, out Transform anchor)
    {
        switch (point)
        {
            case KinectBonePointLR.Head: anchor= m_head;                            break;
            case KinectBonePointLR.Neck: anchor = m_neck;                 break;
            case KinectBonePointLR.SpineShoulder: anchor = m_spineShoulder;        break;
            case KinectBonePointLR.SpineMiddle: anchor = m_spineMiddle;          break;
            case KinectBonePointLR.SpineBase: anchor = m_spineBase;            break;
            case KinectBonePointLR.ShoulderLeft: anchor = m_shoulderLeft;         break;
            case KinectBonePointLR.ElbowLeft: anchor = m_elbowLeft;            break;
            case KinectBonePointLR.WristLeft: anchor = m_wristLeft;            break;
            case KinectBonePointLR.HandLeft: anchor = m_handLeft;             break;
            case KinectBonePointLR.HandTipLeft: anchor = m_handTipLeft;          break;
            case KinectBonePointLR.HandThumbLeft: anchor = m_handThumbLeft;        break;
            case KinectBonePointLR.ShoulderRight: anchor = m_shoulderRight;        break;
            case KinectBonePointLR.ElbowRight: anchor = m_elbowRight;           break;
            case KinectBonePointLR.WristRight: anchor = m_wristRight;           break;
            case KinectBonePointLR.HandRight: anchor = m_handRight;            break;
            case KinectBonePointLR.HandTipRight: anchor = m_handTipRight;         break;
            case KinectBonePointLR.HandThumbRight: anchor = m_handThumbRight;       break;
            case KinectBonePointLR.HipLeft: anchor = m_hipLeft;              break;
            case KinectBonePointLR.KneeLeft: anchor = m_kneeLeft;             break;
            case KinectBonePointLR.AnkleLeft: anchor = m_ankleLeft;            break;
            case KinectBonePointLR.FootLeft: anchor = m_footLeft;             break;
            case KinectBonePointLR.HipRight: anchor = m_hipRight;             break;
            case KinectBonePointLR.KneeRight: anchor = m_kneeRight;            break;
            case KinectBonePointLR.AnkleRight: anchor = m_ankleRight;           break;
            case KinectBonePointLR.FootRight: anchor = m_footRight;            break;
            default:
                anchor = null;
                break;
        }
    }

    public void GetWorldPosition(in KinectBonePointLR bone, out Vector3 worldPosition)
    {
        Get(bone, out Transform t);
        worldPosition = t.position;
    }
    public void GetLocalPosition(in KinectBonePointLR bone, in Transform compareTo, out Vector3 localPosition)
    {
        Vector3 v= compareTo.position;
        Quaternion q = compareTo.rotation;
        GetLocalPosition(in bone, in v, in q, out localPosition);
    }
    public void GetLocalPosition(in KinectBonePointLR bone, in Vector3 pointRoot, in Quaternion rotationRoot, out Vector3 localPosition)
    {
        Get(bone, out Transform t);
        localPosition = t.position-pointRoot;
        localPosition = Quaternion.Inverse(rotationRoot) * localPosition;
    }
}

[System.Serializable]
public class BonesArrayValue<T>
{
    public T[] m_valuePerBone = new T[25];

    public void Set(in KinectBonePointLR indexBone, T value)
    {
        KinectEnumsConert.ConvertToArrayIndex(in indexBone, out short id);
        m_valuePerBone[id] = value;
    }
    public void Get(in KinectBonePointLR indexBone, out T value)
    {
        KinectEnumsConert.ConvertToArrayIndex(in indexBone, out short id);
        value = m_valuePerBone[id];
    }
}

[System.Serializable]
public class BonesNativeArrayValue<T> where T :  struct
{
    public NativeArray<T> m_valuePerBone;

    public void Init(Unity.Collections.Allocator allocationType) {
        T[] values = new T[24];
        m_valuePerBone = new NativeArray<T>(values, allocationType);
    }
    public void Dispose() {
        if(m_valuePerBone.IsCreated)
        m_valuePerBone.Dispose();
    }

    public void Set(KinectBonePointLR indexBone, T value)
    {
        KinectEnumsConert.ConvertToArrayIndex(in indexBone, out short id);
        m_valuePerBone[id] = value;
    }
    public void Get(KinectBonePointLR indexBone, out T value)
    {
        KinectEnumsConert.ConvertToArrayIndex(in indexBone, out short id);
        value = m_valuePerBone[id];
    }

}

[System.Serializable]
public class BonesArrayVector3 : BonesArrayValue<Vector3>
{

}
[System.Serializable]
public class BonesArrayVector2 : BonesArrayValue<Vector2>
{

}
[System.Serializable]
public class BonesArrayBool : BonesArrayValue<bool>
{

}
[System.Serializable]
public class BonesArrayTransform : BonesArrayValue<Transform>
{

}
[System.Serializable]
public class BonesArrayGameObject : BonesArrayValue<GameObject>
{

}



[System.Serializable]
public struct KinectPositionPoint
{
    public Vector3 m_kinectRoot;
    public Vector3 m_avatarContainer;
    public Vector3 m_head;
    public Vector3 m_neck;
    public Vector3 m_spineShoulder;
    public Vector3 m_spineMiddle;
    public Vector3 m_spineBase;
    public Vector3 m_shoulderLeft;
    public Vector3 m_elbowLeft;
    public Vector3 m_wristLeft;
    public Vector3 m_handLeft;
    public Vector3 m_handTipLeft;
    public Vector3 m_handThumbLeft;
    public Vector3 m_shoulderRight;
    public Vector3 m_elbowRight;
    public Vector3 m_wristRight;
    public Vector3 m_handRight;
    public Vector3 m_handTipRight;
    public Vector3 m_handThumbRight;
    public Vector3 m_hipLeft;
    public Vector3 m_kneeLeft;
    public Vector3 m_ankleLeft;
    public Vector3 m_footLeft;
    public Vector3 m_hipRight;
    public Vector3 m_kneeRight;
    public Vector3 m_ankleRight;
    public Vector3 m_footRight;
}