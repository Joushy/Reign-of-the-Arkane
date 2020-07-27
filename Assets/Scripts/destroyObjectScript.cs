using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObjectScript : MonoBehaviour {

    [SerializeField] float destroyTime = 0;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
