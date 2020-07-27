using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalRift : MonoBehaviour {


    GameObject player, enemy;
    private bool bleedout, wait;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            enemy = other.gameObject;
            other.GetComponent<Health>().calculateDamage(this.GetComponent<Collider>());
        }
    }

}
