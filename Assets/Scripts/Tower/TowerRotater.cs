using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotater : MonoBehaviour {

    public Transform[] pieces;
    public float[] ratio;
    Quaternion lastRotation;

    public bool playerNear;
	// Use this for initialization
	void Start () {
        Debug.Assert(pieces.Length == ratio.Length);
        lastRotation = transform.localRotation;
        playerNear = false;
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion delta = Quaternion.Inverse(lastRotation) * transform.localRotation;

        lastRotation = transform.localRotation;

        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].transform.localRotation *= Quaternion.Slerp(Quaternion.identity, delta, ratio[i]); ;
        }
        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    private void LateUpdate()
    {
        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y ,0);
        
    }

    public void ConstrainMovement(Transform pos, Vector3 velocity)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("working...?");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entering");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Stopping");
        if (other.tag == "Player")
        {
            //Debug.Log("Stopping");
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
    }

    public void StopRotation()
    {
        Debug.Log("moving out of range");
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }
}
