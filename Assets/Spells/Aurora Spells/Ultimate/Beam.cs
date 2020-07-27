using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Beam : MonoBehaviour {

    GameObject player, enemy;
    float normalSpeed;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Health>().invinc = true;
        Time.timeScale  = 1;
        player.transform.GetComponent<Animator>().speed *= .2f;
        StartCoroutine("kill");
    }
	
	// Update is called once per frame
	void Update () {
	}

    private IEnumerator kill()
    {
        yield return new WaitForSeconds(2);
        try {enemy.GetComponent<NavMeshAgent>().isStopped = false; } catch { }
        
        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            normalSpeed = other.GetComponent<NavMeshAgent>().speed;
            enemy = other.gameObject;
            other.GetComponent<NavMeshAgent>().isStopped = true;
            other.GetComponent<Health>().calculateDamage(this.GetComponent<Collider>());
        }
    }
}
