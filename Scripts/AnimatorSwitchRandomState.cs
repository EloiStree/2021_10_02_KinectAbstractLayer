using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSwitchRandomState : MonoBehaviour
{
    public Animation m_affected;
    public Animator m_animator;
    public AnimationClip [] m_animationInList;


    public void Awake()
    {
        if (m_affected != null) { 
            int i=0;
            foreach (var item in m_animationInList)
            {
                i++;
                m_affected.AddClip(item, ""+i);
            }
        }
    }

    public void SwitchRandomState() {
            int index = UnityEngine.Random.Range(0, m_animationInList.Length);
        if (m_affected != null)
        {
            m_affected.clip = m_animationInList[index];
            m_affected.Play( "" + index, PlayMode.StopAll );
        }
        if (m_animator) {

            m_animator.Play(m_animationInList[index].name);
        }
    }
}
