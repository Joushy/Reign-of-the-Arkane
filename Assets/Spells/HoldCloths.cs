using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCloths : MonoBehaviour {

    public GameObject clothes0;
    public GameObject clothes1;
    public GameObject clothes2;
    public GameObject clothes3;
    public GameObject clothes4;
    public GameObject clothes5;
    public GameObject clothes6;
    public GameObject clothes7;
    public GameObject clothes8;

    public List<GameObject> clothes;

    // Use this for initialization
    void Start () {
        clothes = new List<GameObject>();
        clothes.Add(this.GetComponent<HoldCloths>().clothes0); clothes.Add(this.GetComponent<HoldCloths>().clothes1); clothes.Add(this.GetComponent<HoldCloths>().clothes2);
        clothes.Add(this.GetComponent<HoldCloths>().clothes3); clothes.Add(this.GetComponent<HoldCloths>().clothes4); clothes.Add(this.GetComponent<HoldCloths>().clothes5);
        clothes.Add(this.GetComponent<HoldCloths>().clothes6); clothes.Add(this.GetComponent<HoldCloths>().clothes7); clothes.Add(this.GetComponent<HoldCloths>().clothes8);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
