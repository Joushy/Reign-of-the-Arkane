using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{

    bool cool = true;
    [SerializeField] GameObject aqua, igni, lux, aero;
    NavMeshAgent agent;
    GameObject player, enemy;
    Vector3 pos;
    int n = 0;

    // Use this for initialization
    void Start()
    {
        agent = aqua.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (cool) { StartCoroutine("spawnOne"); }
        //if (Input.GetKeyDown(KeyCode.X)) { opSide(); Instantiate(agent, pos, Quaternion.identity); }
    }

    private IEnumerator spawnOne()
    {

        if(GameObject.FindGameObjectsWithTag("Enemy").Length < 13)
        {
            cool = false;
            for (int i = 0; i < 4; i++)
            {
                opSide();
                while (Vector3.Distance(player.transform.position, pos) < 30) { opSide(); }
                opSide(); Instantiate(enemy, pos, Quaternion.identity);
            }
            yield return new WaitForSecondsRealtime(9);
            cool = true;
        }

        
    }

    private void opSide()
    {
        pickEnemy();
        int num = Random.Range(0, 4);
        switch (num)
        {
            case 0:
                pos = new Vector3(Random.Range(65, 425), .25f, 25);
                break;
            case 1:
                pos = new Vector3(475, .25f, Random.Range(70, 430));
                break;
            case 2:
                pos = new Vector3(Random.Range(65, 430), .25f, 475);
                break;
            case 3:
                pos = new Vector3(25, .25f, Random.Range(70, 430));
                break;
        }
    }

    private void pickEnemy()
    {
        int num = Random.Range(0, 4);
        switch (num)
        {
            case 0:
                enemy = aqua;
                break;
            case 1:
                enemy = igni;
                break;
            case 2:
                enemy = lux;
                break;
            case 3:
                enemy = aero;
                break;
        }
    }
}
