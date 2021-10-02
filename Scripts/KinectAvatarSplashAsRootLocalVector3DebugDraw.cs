using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectAvatarSplashAsRootLocalVector3DebugDraw : MonoBehaviour
{
    public Transform m_usedRootTransform;
    public KinectAvatarSplashAsRootLocalVector3 m_source;
    public float m_lineSize = 0.1f;
    [Range(0f,1f)]
    public float m_transparentFactor = 0.5f;
    public Vector3 m_offsetViewer= Vector3.up*10;
    public void Update()
    {
        Vector3 point = new Vector3();

        Vector3 worldPoint = new Vector3();
        Vector3 frontalLocalPosition = new Vector3();
        Vector3 sideLocalPosition = new Vector3();
        Vector3 groundLocalPosition = new Vector3();
        float delta = Time.deltaTime;
        KinectUtility.GetAllBones(out KinectBonePointLR[] bones);
        for (int i = 0; i < bones.Length; i++)
        {
            m_source.m_frontalSplash.Get(in bones[i], out  frontalLocalPosition);
            KinectUtility.ConvertLocalToWorld(in m_usedRootTransform, in frontalLocalPosition, out worldPoint);
            worldPoint += m_offsetViewer;
            Debug.DrawLine(worldPoint - m_usedRootTransform.forward * m_lineSize,
                worldPoint + m_usedRootTransform.forward * m_lineSize, Color.blue* m_transparentFactor, delta);

            m_source.m_sideSplash.Get(in bones[i], out  sideLocalPosition);
            KinectUtility.ConvertLocalToWorld(in m_usedRootTransform, in sideLocalPosition, out worldPoint);
            worldPoint += m_offsetViewer;
            Debug.DrawLine(worldPoint - m_usedRootTransform.right * m_lineSize,
                worldPoint + m_usedRootTransform.right * m_lineSize, Color.red* m_transparentFactor, delta);

            m_source.m_groundSplash.Get(in bones[i], out  groundLocalPosition);
            KinectUtility.ConvertLocalToWorld(in m_usedRootTransform, in groundLocalPosition, out worldPoint);
            worldPoint += m_offsetViewer;
            Debug.DrawLine(worldPoint - m_usedRootTransform.up * m_lineSize,
                worldPoint + m_usedRootTransform.up * m_lineSize, Color.green* m_transparentFactor, delta);

        }
    }

   

}
