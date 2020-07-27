using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    Controller player;

    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    [SerializeField] GameObject obj3;

    public float kills = 0f;

	// Use this for initialization
	void Start () {
		
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();

    }
	
	// Update is called once per frame
	void Update () {

        obj1.GetComponent<Text>().text = kills + "";
        obj2.GetComponent<Text>().text = kills + "";
        obj3.GetComponent<Text>().text = kills + "";

    }
}
