using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldownCircle : MonoBehaviour {

    Image img;
    [SerializeField] float cooldown = 0.5f;

    [SerializeField] Image ability2;
    [SerializeField] Image ability3;
    [SerializeField] Image ability4;

    private float startTime2;
    private float elapsedTime2;
    private float overallTime2;

    private float startTime3;
    private float elapsedTime3;
    private float overallTime3;

    private float startTime4;
    private float elapsedTime4;
    private float overallTime4;

    private bool start2;
    private bool start3;
    private bool start4;

    private float ability2CoolDown;
    private float ability3CoolDown;
    private float ability4CoolDown;

    // Use this for initialization
    void Start () {

        try
        {
            ability2 = GameObject.Find("Ability1").GetComponent<Image>();
            ability3 = GameObject.Find("Ability2").GetComponent<Image>();
            ability4 = GameObject.Find("Ability3").GetComponent<Image>();
        } catch
        {

        }
        

        //img = GetComponent<Image>();
        ability2.fillAmount = 1;
        ability2CoolDown = this.GetComponent<SpellHandler>().aqua2.GetComponent<Spell>().cooldownTime;
        ability3.fillAmount = 1;
        ability3CoolDown = this.GetComponent<SpellHandler>().igni3.GetComponent<Spell>().cooldownTime;
        ability4.fillAmount = 1;
        ability4CoolDown = this.GetComponent<SpellHandler>().igni3.GetComponent<Spell>().cooldownTime;
    }
	
	// Update is called once per frame
	void Update () {
        try
        {
            ability2 = GameObject.Find("Ability1").GetComponent<Image>();
            ability3 = GameObject.Find("Ability2").GetComponent<Image>();
            ability4 = GameObject.Find("Ability3").GetComponent<Image>();

            if (start2)
            {
                if (startTime2 + ability2CoolDown > Time.realtimeSinceStartup) { ability2.fillAmount = (Time.realtimeSinceStartup - startTime2) / overallTime2; }
                else { start2 = false; this.GetComponent<Controller>().ability2 = false; }
            }
            else { if (ability2.fillAmount != 1) { ability2.fillAmount += .01f; } }

            if (start3)
            {
                if (startTime3 + ability3CoolDown > Time.realtimeSinceStartup) { ability3.fillAmount = (Time.realtimeSinceStartup - startTime3) / overallTime3; }
                else { start3 = false; this.GetComponent<Controller>().ability3 = false; }
            }
            else { if (ability3.fillAmount != 1) { ability3.fillAmount += .01f; } }

            if (start4)
            {
                if (startTime4 + ability4CoolDown > Time.realtimeSinceStartup) { ability4.fillAmount = (Time.realtimeSinceStartup - startTime4) / overallTime4; }
                else { start4 = false; this.GetComponent<Controller>().ability4 = false; }
            }
            else { if (ability4.fillAmount != 1) { ability4.fillAmount += .01f; } }

        } catch
        {

        }
        

        
    }

    private void ability2Reset() {
        ability2.fillAmount = 0;
        startTime2 = Time.realtimeSinceStartup;
        elapsedTime2 = startTime2 + ability2CoolDown;
        overallTime2 = elapsedTime2 - startTime2;

        start2 = true;
        this.GetComponent<Controller>().ability2 = true;

    }

    private void ability3Reset()
    {
        ability3.fillAmount = 0;
        startTime3 = Time.realtimeSinceStartup;
        elapsedTime3 = startTime3 + ability3CoolDown;
        overallTime3 = elapsedTime3 - startTime3;
        start3 = true;
        this.GetComponent<Controller>().ability3 = true;

    }

    private void ability4Reset()
    {
        ability4.fillAmount = 0;
        startTime4 = Time.realtimeSinceStartup;
        elapsedTime4 = startTime4 + ability4CoolDown;
        overallTime4 = elapsedTime4 - startTime4;
        start4 = true;
        this.GetComponent<Controller>().ability4 = true;

    }
}
