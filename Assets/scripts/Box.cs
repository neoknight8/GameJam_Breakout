using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    Animator animator;
    ShakeAnimationListener shakeListener;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetShakeAnimationListener(ShakeAnimationListener listener)
    {
        shakeListener = listener;
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
        if(shakeListener != null)
        {
            shakeListener.OnAnimationFinished(this);
        }
    }

    public interface ShakeAnimationListener
    {
        void OnAnimationFinished(Box box);
    }


}
