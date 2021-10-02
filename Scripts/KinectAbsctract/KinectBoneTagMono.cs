using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectBoneTagMono : MonoBehaviour
{

    public KinectBonePointLR m_kinectPoint;
    public Transform m_linked;

    public Transform GetLinkedTransform()
    {
        return m_linked;
    }

    [ContextMenu("Reset Transform as itself")]
    public void Reset()
    {
        m_linked = this.transform;
    }
}


