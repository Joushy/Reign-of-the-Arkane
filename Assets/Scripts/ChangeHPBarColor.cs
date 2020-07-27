using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHPBarColor : MonoBehaviour {

    Controller player;

    [SerializeField] Sprite imgBlue;
    [SerializeField] Sprite imgRed;
    [SerializeField] Sprite imgGreen;
    [SerializeField] Sprite imgYellow;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
       
    }
	
	// Update is called once per frame
	void Update () {

        if (player.mode == 1) // water
        {
            GetComponent<Image>().sprite = imgBlue;
        }
        else if (player.mode == 2) // fire
        {

            GetComponent<Image>().sprite = imgRed;
        }
        else if (player.mode == 3)// lightning
        {

            GetComponent<Image>().sprite = imgYellow;
        }
        else if (player.mode == 4)// wind
        {

            GetComponent<Image>().sprite = imgGreen;
        }

    }
}
