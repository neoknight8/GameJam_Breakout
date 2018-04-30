using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager> {
    Vector3[] ball_positions = { new Vector3(2,2,0), new Vector3(2.3f,2,0), new Vector3(2.6f, 2, 0) };
    Vector3 initial_position = new Vector3(0, 2.5f, 0);
    GameObject current_ball;
    ArrayList balls;
    int ball_count = 3;
    [SerializeField]
    TextMesh count_text;
	// Use this for initialization
	void Start () {
        LoadBall();
        BlockManager.Instance.Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadBall()
    {
        balls = new ArrayList();
        GameObject ball_prehab = (GameObject)Resources.Load("prehabs/ball");
        for (int i=0; i<3; i++)
        {
            GameObject ball = Instantiate(ball_prehab);
            ball.transform.position = ball_positions[i];
            balls.Add(ball);
        }
    }

    public void SetNextBall()
    {
        if(current_ball != null)
        {
            Destroy(current_ball);
        }
        ball_count--;
        if (ball_count < 0)
        {
            GameOver();
        }
        current_ball = (GameObject)balls[ball_count];
        current_ball.transform.position = initial_position;
        StartCoroutine("Set");
    }

    IEnumerator Set()
    {
        current_ball.GetComponent<SphereCollider>().enabled = false;
        for(int i = 3; i > 0; i--)
        {
            count_text.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        count_text.text = "";
        current_ball.GetComponent<SphereCollider>().enabled = true;
        current_ball.GetComponent<Rigidbody>().AddForce(new Vector3(5, -4, 0), ForceMode.VelocityChange);
    }

    private void GameOver()
    {
        Debug.Log("gameover");
        SceneManager.LoadScene("gameover");
    }

    public void Clear()
    {
        Debug.Log("clear");
        SceneManager.LoadScene("clear");
    }
}
