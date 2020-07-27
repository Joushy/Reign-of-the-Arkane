using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextColorTitleOnly : MonoBehaviour {


    [SerializeField] float secondsInBetweenSwap;
    [SerializeField] GameObject obj;

    [SerializeField] Color blue;
    [SerializeField] Color red;
    [SerializeField] Color yellow;
    [SerializeField] Color green;

    [SerializeField] Material bcol;
    [SerializeField] Material rcol;
    [SerializeField] Material ycol;
    [SerializeField] Material gcol;

    Controller player;
    bool b = true;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();

    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log(GameObject.Find("BetterCrystal01").GetComponent<MeshRenderer>().materials[0]);

        if(GameObject.Find("BetterCrystal01").GetComponent<MeshRenderer>().materials[0] == bcol)
        {
            Debug.Log("here");
            GetComponent<Text>().color = blue;
        }
        if (GameObject.Find("BetterCrystal01").GetComponent<MeshRenderer>().materials[0] == rcol)
        {
            GetComponent<Text>().color = red;
        }
        if (GameObject.Find("BetterCrystal01").GetComponent<MeshRenderer>().materials[0] == ycol)
        {
            GetComponent<Text>().color = yellow;
        }
        if (GameObject.Find("BetterCrystal01").GetComponent<MeshRenderer>().materials[0] == gcol)
        {
            GetComponent<Text>().color = green;
        }

    }

}
