using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScreen : MonoBehaviour {

    Controller player;

	// Use this for initialization
	void Start () {
		
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();

    }
	
	// Update is called once per frame
	void Update () {
		


	}
}
