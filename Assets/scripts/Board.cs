using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    void move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(new Vector3(0.1f,0,0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(new Vector3(-0.1f, 0, 0));
        }
    }
}
