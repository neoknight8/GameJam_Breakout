using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationUtil : MonoBehaviour {
    public UnityEvent OnAnimaionFinished;
    public void OnAnimationFinished()
    {
        OnAnimaionFinished.Invoke();
    }
}
