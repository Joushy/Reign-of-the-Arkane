using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextColor : MonoBehaviour {

    [SerializeField] ParticleSystem p1;
    [SerializeField] ParticleSystem p2;
    [SerializeField] ParticleSystem p3;
    [SerializeField] ParticleSystem p4;
    [SerializeField] ParticleSystem p5;
    [SerializeField] ParticleSystem p6;
    [SerializeField] ParticleSystem p7;
    [SerializeField] ParticleSystem p8;

    [SerializeField] Color bcol;
    [SerializeField] Color rcol;
    [SerializeField] Color ycol;
    [SerializeField] Color gcol;

    Controller player;
    Controller player2;

    bool b = true;

    // Use this for initialization
    void Start () {

        player = GameObject.Find("Player").GetComponent<Controller>();
        player2 = GameObject.Find("Low Poly Player").GetComponent<Controller>();

        p1 = GameObject.Find("ExplosionEffectWater").GetComponent<ParticleSystem>();
        p2 = GameObject.Find("ExplosionEffectWater2").GetComponent<ParticleSystem>();
        p3 = GameObject.Find("ExplosionEffectFire").GetComponent<ParticleSystem>();
        p4 = GameObject.Find("ExplosionEffectFire2").GetComponent<ParticleSystem>();
        p5 = GameObject.Find("ExplosionEffectLux").GetComponent<ParticleSystem>();
        p6 = GameObject.Find("ExplosionEffectLux2").GetComponent<ParticleSystem>();
        p7 = GameObject.Find("ExplosionEffectAero").GetComponent<ParticleSystem>();
        p8 = GameObject.Find("ExplosionEffectAero2").GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {

        if(b)
        {
            StartCoroutine(oof());
        }
        

	}

    public IEnumerator oof()
    {
        b = false;
        yield return new WaitForSeconds(2f);
        this.GetComponent<Text>().color = rcol;
        player.mode = 2;
        player2.mode = 2;
        //p3.Play();
        //p4.Play();
        yield return new WaitForSeconds(2f);
        this.GetComponent<Text>().color = ycol;
        player.mode = 3;
        player2.mode = 3;
        //p5.Play();
        //p6.Play();
        yield return new WaitForSeconds(2f);
        this.GetComponent<Text>().color = gcol;
        player.mode = 4;
        player2.mode = 4;
        //p7.Play();
       //p8.Play();
        yield return new WaitForSeconds(2f);
        this.GetComponent<Text>().color = bcol;
        player.mode = 1;
        player2.mode = 1;
        //p1.Play();
        //p2.Play();
        b = true;
    }

}
