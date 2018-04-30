using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollector : MonoBehaviour {

    int block_count = BlockManager.BLOCK_COUNT;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Block")
        {
            Debug.Log("Ball Collected");
            block_count--;
            if(block_count <= 0)
            {
                GameManager.Instance.Clear();
            }
        }
    }
}
