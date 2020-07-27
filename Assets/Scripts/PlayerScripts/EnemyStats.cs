using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {

    public enum type { aqua, igni, aero, lux, standard};
    public type elementType;
    GameObject target, player;
    float speed;
    [SerializeField] SkinnedMeshRenderer mesh1, mesh2, mesh3;
    [SerializeField] GameObject structure;

    [Range(0,2)]
    public int aquaResistance, igniResistance, aeroResistance, luxResistance;

    [SerializeField] GameObject p1;
    [SerializeField] GameObject scoreManager;

    public NavMeshAgent agent;
    private Animator anim;
    bool dead, boom;
    float dis;


    // Use this for initialization
    void Start () {
        scoreManager = GameObject.Find("EndGameManager");
        target = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player");
        anim = this.GetComponent<Animator>();
        anim.SetInteger("animation", 0);
        speed = agent.speed;
    }
	
	// Update is called once per frame
	void Update () {

        //if enemy dies, plays death anim
        if (dead) { anim.SetInteger("animation", 14); this.GetComponent<BoxCollider>().enabled = false; target = this.gameObject; this.transform.Find("Canvas").gameObject.SetActive(false); }

        //if health drops below 0, enemy dies.
        if(this.GetComponent<Health>().currentHealth <= 0)
        {
            if (!dead)
            {
                scoreManager.GetComponent<ScoreManager>().kills += 1;
            }
            dead = true;

            Destroy(gameObject, 20f);

            
        }

        agent.SetDestination(target.transform.position);

        //measures distance from player, if close enough, skeleton blows up.
        dis = Vector3.Distance(target.transform.position, this.transform.position);
        if (dis < 10 && !dead && !boom && !target.GetComponent<Controller>().hault) { boom = true; anim.SetInteger("animation", 13); target = this.gameObject; StartCoroutine("blowUp");  }

    }

    private IEnumerator blowUp()
    {
        yield return new WaitForSeconds(.5f);
        this.transform.Find("Canvas").gameObject.SetActive(false);
        structure.SetActive(false);
        mesh1.enabled = false;
        mesh2.enabled = false;
        mesh3.enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        if (Vector3.Distance(player.transform.position, this.gameObject.transform.position) <= 15) { player.GetComponent<Health>().minusPlayerHealth(12); }

        //Insert Particle System here. After, Delete Object.


        p1.GetComponent<ParticleSystem>().gameObject.SetActive(true);
        Destroy(gameObject, 1.2f);
    }
}
