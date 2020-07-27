using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {

    [SerializeField] GameObject samurikeHighlight;
    [SerializeField] GameObject auroraHighlight;
    [SerializeField] GameObject samurike;
    [SerializeField] GameObject aurora;

    [SerializeField] GameObject characterSelect;
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject cameraa;

    [SerializeField] GameObject title;
    [SerializeField] GameObject menuCam;


    MapColorChange mp;
    MusicBeatChange mb;

    AudioSource audioData2;
    bool soundTog, soundTog2;
    [SerializeField] AudioClip pickSound, backSound;

    Controller player;

    bool sam, aur, goAhead = false;

    // Use this for initialization
    void Start () {

        //mb = GetComponent<MusicBeatChange>();
        //mp = GetComponent<MapColorChange>();

        /*
        samurike = GameObject.Find("Player");
        aurora = GameObject.Find("Low Poly Player");
        characterSelect = GameObject.Find("CharacterSelection");
        gameMenu = GameObject.Find("GameMenu");

        cameraa = GameObject.Find("MainCameraHandle");
        

        title = GameObject.Find("EverythingTitle");
        menuCam = GameObject.Find("MenuCamera");
        */
    }
	
	// Update is called once per frame
	void Update () {

        audioData2 = GetComponent<AudioSource>();

        try
        {
            mb = GetComponent<MusicBeatChange>();
            mp = GetComponent<MapColorChange>();
        }
        catch
        {

        }

        if (Input.GetButtonUp("A"))
        {
            audioData2.PlayOneShot(pickSound);
            soundTog2 = false;
            goAhead = true;
            aur = true;
            sam = false;
            try
            {
                if (soundTog != true)
                {
                    
                    soundTog = true;
                }
                auroraHighlight.SetActive(true);
                samurikeHighlight.SetActive(false);

            } catch
            {

            }
            

        }

        if(Input.GetButtonUp("X"))
        {
            audioData2.PlayOneShot(pickSound);
            goAhead = true;
            aur = false;
            sam = true;
            try
            {
                if (soundTog2 != true)
                {
                    
                    soundTog2 = true;
                }
                samurikeHighlight.SetActive(true);
                auroraHighlight.SetActive(false);
            }
            catch
            {

            }


            
        }

        
        if (Input.GetButtonUp("B"))
        {
            audioData2.PlayOneShot(backSound);

            try { mainMenu.SetActive(true); } catch { }
            characterSelect.SetActive(false);
        }

        if (Input.GetButtonUp("Start"))
        {
            if(goAhead)
            {
                if (sam)
                {
                    
                    samurike.SetActive(true);
                        aurora.SetActive(false);
                        samurike.GetComponent<Controller>().enabled = true;
                        samurike.GetComponent<Controller>().mode = 1;

                }
                else if(aur)
                {
                    aurora.SetActive(true);
                    samurike.SetActive(false);
                        aurora.GetComponent<Controller>().enabled = true;
                        aurora.GetComponent<Controller>().mode = 1;
                }

                try
                {
                    characterSelect.SetActive(false);
                    gameMenu.SetActive(true);
                    cameraa.SetActive(true);
                    menuCam.SetActive(false);
                    title.SetActive(false);
                    mb.enabled = false;
                    mp.enabled = true;

                    GameObject.Find("Player").GetComponent<Controller>().mode = 1;
                    GameObject.Find("Low Poly Player").GetComponent<Controller>().mode = 1;

                }
                catch
                {

                }
                
            }
            


        }

    }
}
