using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnShakeFinished(Box box);

public class Box : MonoBehaviour {
    Animator animator;
    OnShakeFinished onAnimationFinished;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetShakeAnimationListener(OnShakeFinished _listener)
    {
        onAnimationFinished = _listener;
    }

    public void AnimationStart()
    {
        animator.SetBool("shake", true);
    }

    public void AnimationReset()
    {
        animator.SetBool("shake", false);
    }

    public void OnAnimationFinished()
    {
        onAnimationFinished(this);
    }
}
