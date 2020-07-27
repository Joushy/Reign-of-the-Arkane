using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Health : MonoBehaviour
{

    private bool wait, damageMe;

    [SerializeField] float maxHealth;

    public float damage, currentHealth, nextHealth;
    public bool invinc;
    Animator anim;

    [SerializeField] Image imgHP;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.tag == "Player")
        {

            if(Input.GetButtonUp("GodMode"))
            {
                currentHealth = 100000;
            } else
            {
                if (currentHealth > maxHealth) { currentHealth = maxHealth; }
            }

            imgHP.fillAmount = currentHealth / maxHealth;
            
            if (damageMe && !invinc)
            {
                currentHealth = Mathf.Lerp(currentHealth, nextHealth, .2f);
                if((int)currentHealth == (int)nextHealth) { damageMe = false; }
            }
        }

        if(transform.tag == "Enemy")
        {
            imgHP.fillAmount = currentHealth / maxHealth;

            if (damageMe)
            {
                currentHealth = Mathf.Lerp(currentHealth, nextHealth, .2f);
                if ((int)currentHealth == (int)nextHealth) { damageMe = false; }
            }
        }

    }

    public void getHealth(float num)
    {
        currentHealth += num;
        
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

    }


    public void calculateDamage(Collider other)
    {
        switch (other.GetComponent<Spell>().elementType)
        {
            case Spell.type.aqua:
                switch (this.GetComponent<EnemyStats>().aquaResistance)
                {
                    case 0:
                        damage = other.GetComponent<Spell>().damage * 2;
                        break;
                    case 1:
                        damage = other.GetComponent<Spell>().damage;
                        break;
                    case 2:
                        damage = other.GetComponent<Spell>().damage / 2;
                        break;
                }
                break;
            case Spell.type.igni:
                switch (this.GetComponent<EnemyStats>().igniResistance)
                {
                    case 0:
                        damage = other.GetComponent<Spell>().damage * 2;
                        break;
                    case 1:
                        damage = other.GetComponent<Spell>().damage;
                        break;
                    case 2:
                        damage = other.GetComponent<Spell>().damage / 2;
                        break;
                }
                break;
            case Spell.type.lux:
                switch (this.GetComponent<EnemyStats>().luxResistance)
                {
                    case 0:
                        damage = other.GetComponent<Spell>().damage * 2;
                        break;
                    case 1:
                        damage = other.GetComponent<Spell>().damage;
                        break;
                    case 2:
                        damage = other.GetComponent<Spell>().damage / 2;
                        break;
                }
                break;
            case Spell.type.aero:
                switch (this.GetComponent<EnemyStats>().aeroResistance)
                {
                    case 0:
                        damage = other.GetComponent<Spell>().damage * 2;
                        break;
                    case 1:
                        damage = other.GetComponent<Spell>().damage;
                        break;
                    case 2:
                        damage = other.GetComponent<Spell>().damage / 2;
                        break;
                }
                break;
        }
        nextHealth = currentHealth - damage;
        damageMe = true;
    }

    public void giveHealth(float giveAmount)
    {
        if(currentHealth < 100) {currentHealth += giveAmount; }
        else { currentHealth = 100; }
    }

    public void minusPlayerHealth(float num) {
        nextHealth = currentHealth - num;
        damageMe = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (this.transform.tag == "Enemy" && other.transform.tag != "Player")
        {
            if (other.transform.tag == "Cantrip")
            {
                try { calculateDamage(other); } catch { }
            }
        }
    }

    public void Iframess()
    {
        StartCoroutine("Invincible");
    }

    private IEnumerator Invincible()
    {
        wait = true;
        yield return new WaitForSeconds(1f);
        wait = false;
    }

}
