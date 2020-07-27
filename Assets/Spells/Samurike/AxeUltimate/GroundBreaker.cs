using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBreaker : MonoBehaviour
{
    GameObject player;
    bool wait;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Health>().invinc = true;

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            
            if (player.GetComponent<Controller>().hit)
            {
                other.GetComponent<Health>().calculateDamage(this.GetComponent<Collider>());
            } 
        }
    }

}
