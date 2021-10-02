using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectAvatarSplashAsRootLocalVector3PrimitiveDebug : MonoBehaviour
{

    public Material m_materialToUse;
    public PrimitiveType m_primitiveType;

    public Transform m_usedRootTransform;
    public KinectAvatarSplashAsRootLocalVector3 m_source;

    public Transform m_parentFrontal;
    public Transform m_parentGround;
    public Transform m_parentSide;
    public BonesArrayTransform m_debugObjectFrontal;
    public BonesArrayTransform m_debugObjectGround;
    public BonesArrayTransform m_debugObjectSide;

    public float m_size = 0.05f;
    [Range(0f, 1f)]
    public float m_transparentFactor = 0.5f;
    public Vector3 m_offsetViewer = Vector3.up * 10;


    public void Awake()
    {
        GameObject created = null;
        KinectUtility.GetAllBones(out KinectBonePointLR[] bones);
        for (int i = 0; i < bones.Length; i++)
        {
            created = GameObject.CreatePrimitive(m_primitiveType);
            created.GetComponent<Renderer>().material = m_materialToUse;
            created.GetComponent<Renderer>().material.color = Color.blue* m_transparentFactor;
            Destroy(created.GetComponent<Collider>());
            created.transform.localScale = Vector3.one * m_size;
            created.transform.parent = m_parentFrontal;
            m_debugObjectFrontal.Set(in bones[i], created.transform);


            created = GameObject.CreatePrimitive(m_primitiveType);
            created.GetComponent<Renderer>().material = m_materialToUse;
            created.GetComponent<Renderer>().material.color = Color.green * m_transparentFactor;
            Destroy(created.GetComponent<Collider>());
            created.transform.localScale = Vector3.one * m_size;
            created.transform.parent = m_parentGround;
            m_debugObjectGround.Set(in bones[i], created.transform);


            created = GameObject.CreatePrimitive(m_primitiveType);
            created.GetComponent<Renderer>().material = m_materialToUse;
            created.GetComponent<Renderer>().material.color = Color.red * m_transparentFactor;
            Destroy(created.GetComponent<Collider>());
            created.transform.localScale = Vector3.one * m_size;
            created.transform.parent = m_parentSide;
            m_debugObjectSide.Set(in bones[i], created.transform);

        }
    }

    public void Update()
    {
        Vector3 point = new Vector3();
        Vector3 worldPoint = new Vector3();
        Vector3 frontalLocalPosition = new Vector3();
        Vector3 sideLocalPosition = new Vector3();
        Vector3 groundLocalPosition = new Vector3();
        float delta = Time.deltaTime;
        Transform toAffect;
        KinectUtility.GetAllBones(out KinectBonePointLR[] bones);
        for (int i = 0; i < bones.Length; i++)
        {
            m_source.m_frontalSplash.Get(in bones[i], out frontalLocalPosition);
            KinectUtility.ConvertLocalToWorld(in m_usedRootTransform, in frontalLocalPosition, out worldPoint);
            worldPoint += m_offsetViewer;

            m_debugObjectFrontal.Get(in bones[i], out toAffect);
            toAffect.position = worldPoint;

            m_source.m_sideSplash.Get(in bones[i], out sideLocalPosition);
            KinectUtility.ConvertLocalToWorld(in m_usedRootTransform, in sideLocalPosition, out worldPoint);
            worldPoint += m_offsetViewer;

            m_debugObjectSide.Get(in bones[i], out toAffect);
            toAffect.position = worldPoint;

            m_source.m_groundSplash.Get(in bones[i], out groundLocalPosition);
            KinectUtility.ConvertLocalToWorld(in m_usedRootTransform, in groundLocalPosition, out worldPoint);
            worldPoint += m_offsetViewer;

            m_debugObjectGround.Get(in bones[i], out toAffect);
            toAffect.position = worldPoint;
        }
    }


}
