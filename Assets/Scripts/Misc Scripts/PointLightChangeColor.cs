using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightChangeColor : MonoBehaviour {

    [SerializeField] Color blue;
    [SerializeField] Color red;
    [SerializeField] Color yellow;
    [SerializeField] Color green;

    Controller player;

    Light lite;

    // Use this for initialization
    void Start () {

        lite = GetComponent<Light>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();

    }
	
	// Update is called once per frame
	void Update () {

        if (player.mode == 1) // water
        {
            lite.color = blue;
        }
        else if (player.mode == 2) // fire
        {
            lite.color = red;
        }
        else if (player.mode == 3)// lightning
        {
            lite.color = yellow;
        }
        else if (player.mode == 4)// wind
        {
            lite.color = green;
        }

    }
}
