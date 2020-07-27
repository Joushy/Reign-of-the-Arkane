using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsEndOfGame : MonoBehaviour {

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject title;
    [SerializeField] GameObject gameOverScreen;
    Controller player;

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        try
        {
            player = GameObject.Find("Player").GetComponent<Controller>();
            player = GameObject.Find("Low Poly Player").GetComponent<Controller>();
        } catch
        {

        }
        
        /*
        if (player.GetComponent<Health>().currentHealth > 0)
        {
            gameOverScreen.SetActive(false);
        }*/

        if (Input.GetButtonUp("B"))
        {
            Application.Quit();
        }

        if (Input.GetButtonUp("Start")) // press play
        {
            mainMenu.SetActive(true);
            title.SetActive(true);
            gameObject.SetActive(false);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            //player.GetComponent<Health>().currentHealth = 100;
            
        }

    }
}
