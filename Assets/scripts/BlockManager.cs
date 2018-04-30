using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : SingletonMonoBehaviour<BlockManager>
{
    [SerializeField]
    Box box;
    GameObject block_prehab;
    ArrayList blocks;
    public const int BLOCK_COUNT = 15;
    float[] first_pos = { 0.1f, -0.1f, 0.2f, -0.2f };
    	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init()
    {
        block_prehab = (GameObject)Resources.Load("prehabs/block");
        StartCoroutine("InitBlocks");
    }

    IEnumerator InitBlocks()
    {
        blocks = new ArrayList();
        box.SetShakeAnimationListener((box) => box.AnimationReset());
        for (int i = 1; i <= BLOCK_COUNT; i++)
        {
            if(i%5 == 0) { box.AnimationStart(); }
            GameObject block = Instantiate(block_prehab);
            block.transform.Translate(new Vector3(first_pos[Random.Range(0,3)],0,0));
            blocks.Add(block);
            Debug.Log("Block Created");
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(3f);
        GameManager.Instance.SetNextBall();
    }

    public void OnShakeAnimationFinished()
    {
        Animator animator = box.GetComponent<Animator>();
        animator.SetBool("shake", false);
    }

}
