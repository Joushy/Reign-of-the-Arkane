using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBeatChange : MonoBehaviour {

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

    [SerializeField] ParticleSystem p9;
    //[SerializeField] Light dropLight;

    [SerializeField] Controller player;

    float Beat1 = 1.4f;
    float Beat2 = 2f;
    float Beat3 = 1.2f;
    float Beat4 = 0.22f;
    float Beat5 = 4f;
    float Beat6 = 0.4f;
    float Beat7 = 0.3f;
    float Beat8 = 0.2f;
    float Beat9 = 0.3f;
    float Beat10 = 0.2f;
    float Beat11 = 0.2f;
    float Beat12 = 0.1f;
    float Beat13 = 0.4f;
    float Beat14 = 0.4f;
    float Beat15 = 0.4f;
    float Beat16 = 0.3f;
    float Beat17 = 0.71f;
    float Beat18 = 0.6f;
    float Beat19 = 0.5f;
    float Beat20 = 0.4f;
    float Beat21 = 0.3f;
    float Beat22 = 0.6f;
    float Beat23 = 0.4f;
    float Beat24 = 0.3f;
    float Beat25 = 0.7f;
    float Beat26 = 0.3f;

    [SerializeField] MapColorChange mp;
    [SerializeField] MusicBeatChange mb;

    public MeshRenderer mesh;

    // Use this for initialization
    void Start () {

        //dropLight = GameObject.Find("DropLight").GetComponent<Light>();
        mp = GetComponent<MapColorChange>();
        mb = GetComponent<MusicBeatChange>();

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

        StartCoroutine(beat());

    }
	
	// Update is called once per frame
	void Update () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();

        if (Input.GetButtonUp("Start"))
        {
            mp.enabled = true;
            mb.enabled = false;
            StopCoroutine(beat());
            
        }

        /*
        if (player.mode == 1) // water
        {
            mesh.material = blue;
        }
        else if (player.mode == 2) // fire
        {
            mesh.material = red;
        }
        else if (player.mode == 3)// lightning
        {
            mesh.material = yellow;
        }
        else if (player.mode == 4)// wind
        {
            mesh.material = green;
        }
        */
    }

    IEnumerator beat()
    {

        yield return new WaitForSeconds(Beat1);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat2);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }

        yield return new WaitForSeconds(Beat3);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat4);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat5);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat6);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }

        yield return new WaitForSeconds(Beat7);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat8);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat9);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }

        yield return new WaitForSeconds(Beat10);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat11);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat12);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat13);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }

        yield return new WaitForSeconds(Beat14);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat15);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat16);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat17);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }

        yield return new WaitForSeconds(Beat18);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat19);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat20);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat21);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }
        yield return new WaitForSeconds(Beat22);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat23);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat25);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat26);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }

        yield return new WaitForSeconds(Beat10);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat11);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat12);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat13);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }

        yield return new WaitForSeconds(Beat14);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat15);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat16);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat17);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }

        yield return new WaitForSeconds(Beat18);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat19);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat20);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat21);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }
        yield return new WaitForSeconds(Beat22);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat23);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat25);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat26);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }

        yield return new WaitForSeconds(Beat10);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat11);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat12);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat13);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }

        yield return new WaitForSeconds(Beat14);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat15);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat16);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat17);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }

        yield return new WaitForSeconds(Beat18);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat19);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat20);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat21);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }
        yield return new WaitForSeconds(Beat22);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = green;
            p7.Play();
            p8.Play();
        }

        yield return new WaitForSeconds(Beat23);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = blue;
            p1.Play();
            p2.Play();
        }

        yield return new WaitForSeconds(Beat25);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = red;
            p3.Play();
            p4.Play();
        }

        yield return new WaitForSeconds(Beat26);
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().isActiveAndEnabled)
        {
            mesh.material = yellow;
            p5.Play();
            p6.Play();
        }

        //dropLight.enabled = true;

        mp.enabled = true;
        this.enabled = false;

    }


}
