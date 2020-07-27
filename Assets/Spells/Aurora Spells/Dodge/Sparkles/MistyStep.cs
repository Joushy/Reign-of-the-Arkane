using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistyStep : MonoBehaviour
{

    private GameObject player;
    public List<GameObject> clothes;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
        clothes = player.GetComponent<HoldCloths>().clothes;
        disAppear();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Stop")
            {
                rb.isKinematic = false;
                //player.GetComponent<BoxCollider>().isTrigger = false;
            }
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.red);
        }

    }

    private void disAppear()
    {
        for (int i = 0; i < clothes.Count; i++)
        {
            clothes[i].GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
        if (player.GetComponent<Controller>().left) { rb.AddForce(Camera.main.transform.right * (-10000f)); } else { rb.AddForce(Camera.main.transform.right * (10000f)); }
        player.GetComponent<BoxCollider>().isTrigger = true;
    }

}
