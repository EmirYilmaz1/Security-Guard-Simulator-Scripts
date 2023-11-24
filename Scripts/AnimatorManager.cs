using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void PlayTargetAnim(string animationName)
    {
        animator.CrossFade(animationName, 0.001f);
    }
}
