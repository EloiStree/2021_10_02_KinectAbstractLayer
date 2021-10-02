using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectAvatarSplashAsRootLocalVector3 : MonoBehaviour
{

    public KinectAvatarPositionAsVector3 m_source;

    public BonesArrayVector3 m_groundSplash;
    public BonesArrayVector3 m_frontalSplash;
    public BonesArrayVector3 m_sideSplash;

    public void Update()
    {
        KinectUtility.GetAllBones(out KinectBonePointLR[] bones);
        for (int i = 0; i <bones.Length; i++)
        {
            KinectBonePointLR bone = bones[i];
            m_source.m_localPosition.Get(in bone, out Vector3 position);
            m_groundSplash.Set(in bone, new Vector3(position.x, 0, position.z));
            m_frontalSplash.Set(in bone, new Vector3(position.x, position.y,0));
            m_sideSplash.Set(in bone, new Vector3(0,position.y, position.z));
        }
    }
}
