using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOnlyTextColor : MonoBehaviour {

    [SerializeField] float secondsInBetweenSwap = 1f;

    [SerializeField] Color bcol;
    [SerializeField] Color rcol;
    [SerializeField] Color ycol;
    [SerializeField] Color gcol;
    bool b = true;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (b)
        {
            StartCoroutine(oof());
        }
    }

    public IEnumerator oof()
    {
        b = false;
        yield return new WaitForSeconds(secondsInBetweenSwap);
        this.GetComponent<Text>().color = rcol;

        yield return new WaitForSeconds(secondsInBetweenSwap);
        this.GetComponent<Text>().color = ycol;

        yield return new WaitForSeconds(secondsInBetweenSwap);
        this.GetComponent<Text>().color = gcol;

        yield return new WaitForSeconds(secondsInBetweenSwap);
        this.GetComponent<Text>().color = bcol;
        b = true;
    }
}
