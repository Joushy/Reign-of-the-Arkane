using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapColorChange : MonoBehaviour {

    [SerializeField] Material blue;
    [SerializeField] Material red;
    [SerializeField] Material yellow;
    [SerializeField] Material green;

    [SerializeField] ParticleSystem p1;
    [SerializeField] ParticleSystem p2;
    [SerializeField] ParticleSystem p3;
    [SerializeField] ParticleSystem p4;
    [SerializeField] ParticleSystem p5;
    [SerializeField] ParticleSystem p6;
    [SerializeField] ParticleSystem p7;
    [SerializeField] ParticleSystem p8;

    [SerializeField] Controller player;

    public MeshRenderer mesh;

    // Use this for initialization
    void Start () {
        mesh = GetComponent<MeshRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();

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

        try
        {
            player = GameObject.Find("Low Poly Player").GetComponent<Controller>();
            player = GameObject.Find("Player").GetComponent<Controller>();
        }
        catch
        {

        }
        

        if (player.mode == 1) // water
        {
            //Debug.Log(player.swapping);
            mesh.material = blue;
            if (Input.GetButtonDown("ChangeMode") && player.swapping)
            {
                p1.Play();
                p2.Play();
            }

                
        }
        else if(player.mode == 2) // fire
        {
            mesh.material = red;
            if (Input.GetButtonDown("ChangeMode") && player.swapping)
            {
                p3.Play();
                p4.Play();
                
            }
        }
        else if(player.mode == 3)// lightning
        {
            mesh.material = yellow;
            if (Input.GetButtonDown("ChangeMode") && player.swapping)
            {
                p5.Play();
                p6.Play();
            }
        }
        else if(player.mode == 4)// wind
        {
            mesh.material = green;
            if (Input.GetButtonDown("ChangeMode") && player.swapping)
            {
                p7.Play();
                p8.Play();
            }
        }

	}
}
