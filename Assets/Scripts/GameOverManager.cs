using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject GameMenu;

    [SerializeField] GameObject cameraMainMenu;
    [SerializeField] GameObject cameraGame;

    Controller player;

	// Use this for initialization
	void Start () {

        

    }
	
	// Update is called once per frame
	void Update () {
        try
        {
            player = GameObject.Find("Low Poly Player").GetComponent<Controller>();
            player = GameObject.Find("Player").GetComponent<Controller>();

        } catch
        {

        }
        


        if (player.GetComponent<Health>().currentHealth <= 0)
        {
            player.gameObject.SetActive(false);

            //Instantiate(GameOverScreen);
            GameOverScreen.SetActive(true);
            GameMenu.SetActive(false);

            cameraMainMenu.SetActive(true);
            cameraGame.SetActive(false);

            
        }

	}
}
