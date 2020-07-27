using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSlerp : MonoBehaviour {

    [SerializeField] Controller player;
    [SerializeField] Controller player2;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<Controller>();
        player2 = GameObject.Find("Low Poly Player").GetComponent<Controller>();

    }
	
	// Update is called once per frame
	void Update () {


        if(!player.isActiveAndEnabled && !player2.isActiveAndEnabled)
        {
            
            Camera.main.transform.LookAt(this.transform);
            Camera.main.transform.RotateAround(this.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
        
    }
}
