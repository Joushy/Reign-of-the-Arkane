using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAxeColor : MonoBehaviour {

    [SerializeField] GameObject blue;
    [SerializeField] GameObject red;
    [SerializeField] GameObject yellow;
    [SerializeField] GameObject green;

    Controller player;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();

    }
	
	// Update is called once per frame
	void Update () {

        if (player.mode == 1) // water
        {
            blue.SetActive(true);
            red.SetActive(false);
            yellow.SetActive(false);
            green.SetActive(false);
        }
        else if (player.mode == 2) // fire
        {
            blue.SetActive(false);
            red.SetActive(true);
            yellow.SetActive(false);
            green.SetActive(false);
        }
        else if (player.mode == 3)// lightning
        {
            blue.SetActive(false);
            red.SetActive(false);
            yellow.SetActive(true);
            green.SetActive(false);
        }
        else if (player.mode == 4)// wind
        {
            blue.SetActive(false);
            red.SetActive(false);
            yellow.SetActive(false);
            green.SetActive(true);
        }

    }
}
