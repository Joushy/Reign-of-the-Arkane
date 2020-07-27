using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillNumber : MonoBehaviour {

    ScoreManager sM;

    [SerializeField] Text txt;
    [SerializeField] Text txt2;

    // Use this for initialization
    void Start () {

        
        
	}
	
	// Update is called once per frame
	void Update () {

            sM = GameObject.Find("EndGameManager").GetComponent<ScoreManager>();
            GetComponent<ScoreManager>().kills = sM.kills;

        txt.text = GetComponent<ScoreManager>().kills + "";

        txt2.text = GetComponent<TimerManager>().minutes + ":" + GetComponent<TimerManager>().seconds;

    }
}
