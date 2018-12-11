using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChild : MonoBehaviour {

    public bool playerContact;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!playerContact)
        {
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerContact = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerContact = false;
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
