using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [SerializeField] float destroyIn;
    public enum type { aqua, igni, aero, lux, standard };
    [SerializeField] type currentType;
    private bool takeDamage;
    private float damage;
    [SerializeField] float tickTime;
    private GameObject enemy;
    private bool bleedout;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, destroyIn);
        damage = this.GetComponent<Spell>().damage;

    }

    // Update is called once per frame
    void Update()
    {

        if (takeDamage)
        {
            try { enemy.GetComponent<Health>().calculateDamage(this.GetComponent<Collider>()); } catch { }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            enemy = other.transform.gameObject;
            StartCoroutine("dot");
        }
    }

    private IEnumerator dot()
    {
        takeDamage = true;
        yield return new WaitForSeconds(tickTime);
        takeDamage = false;
    }
}
