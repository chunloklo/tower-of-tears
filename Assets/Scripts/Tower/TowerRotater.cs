﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotater : MonoBehaviour {

    public Transform[] pieces;
    public float[] ratio;
    Quaternion lastRotation;
	// Use this for initialization
	void Start () {
        Debug.Assert(pieces.Length == ratio.Length);
        lastRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion delta = Quaternion.Inverse(lastRotation) * transform.localRotation;

        lastRotation = transform.localRotation;

        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].transform.localRotation *= Quaternion.Slerp(Quaternion.identity, delta, ratio[i]); ;
        }
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y ,0);
        
    }

    public void ConstrainMovement(Transform pos, Vector3 velocity)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }
}
