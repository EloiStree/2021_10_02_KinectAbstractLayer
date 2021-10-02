using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectAvatarPositionAsVector3 : MonoBehaviour
{
    public KinectAvatarTagManagerMono m_source;
    public BonesArrayVector3 m_localPosition;
    public BonesArrayVector3 m_worldPosition;

  
    void Update()
    {
        Transform root = m_source.m_avatarInfo.m_kinectRoot;
        Vector3 rootPosition = root.position;
        Quaternion rootRotation = root.rotation;
        for (int i = 0; i < KinectUtility.m_allBonesPoints.Length; i++)
        {
            KinectBonePointLR b = KinectUtility.m_allBonesPoints[i];
            Vector3 lp;
            Vector3 wp;
             m_source.m_avatarInfo.GetLocalPosition(in b, in rootPosition, in rootRotation, out lp);
             m_source.m_avatarInfo.GetWorldPosition(in b, out wp);
            m_localPosition.Set(b, lp);
            m_worldPosition.Set(b, wp);

        }
        
    }
}
