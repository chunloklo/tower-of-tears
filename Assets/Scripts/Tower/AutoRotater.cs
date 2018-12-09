using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AutoRotater : MonoBehaviour {

    public Rigidbody rb;
    public bool colliding;
    public int numCollide = 0;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        Debug.Log(numCollide);
        if (numCollide == 0)
        {
            Debug.Log("Moving");
            rb.angularVelocity = (new Vector3(0, 1, 0));
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            numCollide += 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            numCollide -= 1;
        }
    }


}
