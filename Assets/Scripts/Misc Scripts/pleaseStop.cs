using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pleaseStop : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<BoxCollider>().isTrigger = false;
    }
}
