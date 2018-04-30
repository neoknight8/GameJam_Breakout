using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public int direction_UD;
    public int direction_LR;
    private const int BALL_UP = 1;
    private const int BALL_DOWN = -1;
    private const int BALL_LEFT = -1;
    private const int BALL_RIGHT = 1;

    Rigidbody rigid_body;

    // Use this for initialization
    void Start () {
        rigid_body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        LimitSpeed();
        setDirection();
	}

    public void LimitSpeed()
    {
        if (Mathf.Abs(rigid_body.velocity.x) > 5)
        {
            rigid_body.velocity = new Vector3(rigid_body.velocity.x / Mathf.Abs(rigid_body.velocity.x) * 5, rigid_body.velocity.y, 0);
        }
        if (Mathf.Abs(rigid_body.velocity.y) > 5)
        {
            rigid_body.velocity = new Vector3(rigid_body.velocity.x, rigid_body.velocity.y / Mathf.Abs(rigid_body.velocity.y) * 5, 0);
        }
    }

    public void CheckSpeed()
    {
        if (Mathf.Abs(rigid_body.velocity.x) < 0.5f)
        {
            rigid_body.AddForce(direction_LR * new Vector3(3f,0,0), ForceMode.VelocityChange);
        }
        if (Mathf.Abs(rigid_body.velocity.y) < 0.5f)
        {
            rigid_body.AddForce(direction_UD * new Vector3(0, 3f, 0), ForceMode.VelocityChange);
        }
    }

    public void setDirection()
    {
        if (rigid_body.velocity.x > 0)
        {
            direction_LR = BALL_RIGHT;
        }else if(rigid_body.velocity.x < 0)
        {
            direction_LR = BALL_LEFT;
        }
        if (rigid_body.velocity.y > 0)
        {
            direction_UD = BALL_UP;
        }
        else if(rigid_body.velocity.y < 0)
        {
            direction_UD = BALL_DOWN;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(20f,20f,0),ForceMode.VelocityChange);
        }
        CheckSpeed();
    }
}
