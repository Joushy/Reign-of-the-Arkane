using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressScript : MonoBehaviour {

    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    [SerializeField] GameObject obj3;
    [SerializeField] GameObject obj4;

    [SerializeField] AudioSource audioData;
    [SerializeField] AudioClip backSound, selectSound;

    Controller player;
    bool rulesToggle = false;
    bool creditToggle = false;

    int counter;

    // Use this for initialization
    void Start () {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>();
    }
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButtonUp("A") && !rulesToggle && !creditToggle) // press play
        {
            //player.mode = 1;
            obj1.SetActive(false);
            obj2.SetActive(true);
        }

        if(Input.GetButtonUp("B"))
        {
            audioData.PlayOneShot(backSound);
            Debug.Log("Quitt");
            Application.Quit();
        }

        if (Input.GetButtonUp("X"))
        {
            audioData.PlayOneShot(selectSound);
            if (!creditToggle)
            {
                obj3.SetActive(true);
                creditToggle = true;
                obj4.SetActive(false);
                rulesToggle = false;
            } else
            {
                obj3.SetActive(false);
                creditToggle = false;
                obj4.SetActive(false);
                rulesToggle = false;
            }
            
            Debug.Log("Credits");
        }

        if (Input.GetButtonUp("Y"))
        {
            audioData.PlayOneShot(selectSound);

            if (!rulesToggle)
            {
                obj4.SetActive(true);
                rulesToggle = true;
                obj3.SetActive(false);
                creditToggle = false;
            }
            else
            {
                obj4.SetActive(false);
                rulesToggle = false;
                obj3.SetActive(false);
                creditToggle = false;
            }


        }

    }




}
