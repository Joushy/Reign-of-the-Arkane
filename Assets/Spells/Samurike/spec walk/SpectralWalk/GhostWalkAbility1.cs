using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostWalkAbility1 : MonoBehaviour {



    GameObject player;
    Spell spell;

    [SerializeField] float durationOfGhostWalk = 3f;

    [SerializeField] Material playerOriginalSkin;
    [SerializeField] Material playerGhostSkin;

    [SerializeField] SkinnedMeshRenderer blueSkin;
    [SerializeField] SkinnedMeshRenderer redSkin;
    [SerializeField] SkinnedMeshRenderer greenSkin;
    [SerializeField] SkinnedMeshRenderer yellowSkin;

    [SerializeField] float SpellCooldownPerUpdate = 0.003f;
    //[SerializeField] Image AbilityCircle;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        //AbilityCircle = GameObject.Find("Ability2").GetComponent<Image>();
        //GameObject.Find("Ability2").GetComponent<AbilityCooldownCircle>().cdPerUpdate = SpellCooldownPerUpdate;

        spell = GetComponent<Spell>();

        blueSkin   = GameObject.Find("blueBody").GetComponent<SkinnedMeshRenderer>();
        redSkin    = GameObject.Find("redBody").GetComponent<SkinnedMeshRenderer>();
        greenSkin  = GameObject.Find("greenBody").GetComponent<SkinnedMeshRenderer>();
        yellowSkin = GameObject.Find("yellowBody").GetComponent<SkinnedMeshRenderer>();

        StartCoroutine(turnGhost());

    }
	
	// Update is called once per frame
	void Update () {



    }

    IEnumerator turnGhost()
    {

            player.GetComponent<BoxCollider>().isTrigger = true;

            if (player.GetComponent<Controller>().mode == 1)
            {
                blueSkin.enabled = true;
            }
            else if (player.GetComponent<Controller>().mode == 2) // fire
            {
                redSkin.enabled = true;
            }
            else if (player.GetComponent<Controller>().mode == 3)// lightning
            {
                yellowSkin.enabled = true;
            }
            else if (player.GetComponent<Controller>().mode == 4)// wind
            {
                greenSkin.enabled = true;
            }



            yield return new WaitForSeconds(durationOfGhostWalk);

            blueSkin.enabled = false;
            redSkin.enabled = false;
            yellowSkin.enabled = false;
            greenSkin.enabled = false;
            player.GetComponent<BoxCollider>().isTrigger = false;

        yield return new WaitForSeconds(.5f);
        player.GetComponent<Controller>().hault = false;
        Destroy(gameObject);
        }
        
    }

    


