using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    public enum type { aqua, igni, aero, lux, standard };
    public type elementType;

    public float damage;
    public int animNum;
    public float startTime;
    public float waitTime;
    public string spawnLoc;
    public string spawnName;
    public Vector3 rotation;
    public float cooldownTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
