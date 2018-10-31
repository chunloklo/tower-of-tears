using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChild : MonoBehaviour {


    public TowerRotater parent;
    public Rigidbody parentRB;

	// Use this for initialization
	void Start () {
        parent = transform.parent.GetComponent<TowerRotater>();
        parentRB = transform.parent.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            parentRB.constraints = RigidbodyConstraints.FreezePositionX |
                                RigidbodyConstraints.FreezePositionY |
                                RigidbodyConstraints.FreezePositionZ |
                                RigidbodyConstraints.FreezeRotationX |
                                RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            parentRB.constraints = RigidbodyConstraints.FreezePositionX |
                                RigidbodyConstraints.FreezePositionY |
                                RigidbodyConstraints.FreezePositionZ | 
                                RigidbodyConstraints.FreezeRotationX |
                                RigidbodyConstraints.FreezeRotationY |
                                RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
