using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    public int minutes = -1;
    int n;
    bool onetime = false;

    double time;
    public int seconds;

    // Use this for initialization
    void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {


        n = (int)Time.time - (int)time;
        seconds = n % 60;
        if (seconds == 0 && !onetime) { onetime = true; minutes++; }
        if (seconds == 59) { onetime = false; }

        if (minutes < 10)
        {

            if(seconds < 10)
            {
                obj1.GetComponent<Text>().text = "0" + minutes + ":" + "0" + seconds;
                obj2.GetComponent<Text>().text = "0" + minutes + ":" + "0" + seconds;
            }
            else
            {
                obj1.GetComponent<Text>().text = "0" + minutes + ":" + seconds;
                obj2.GetComponent<Text>().text = "0" + minutes + ":" + seconds;
            }
        }
        else
        {
            obj1.GetComponent<Text>().text = minutes + ":" + seconds;
            obj2.GetComponent<Text>().text = minutes + ":" + seconds;
        }
    }
}
