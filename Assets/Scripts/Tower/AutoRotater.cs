using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ContactChecker))]
public class AutoRotater : MonoBehaviour {

    public Rigidbody rb;
    public ContactChecker cc;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<ContactChecker>();
	}

    private void FixedUpdate()
    {
        if (cc.InContact())
        { 
            Debug.Log("Moving");
            //rb.angularVelocity = (new Vector3(0, 1, 0));
        }
    }

}
