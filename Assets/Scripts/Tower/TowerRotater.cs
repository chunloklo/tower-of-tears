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
    }
}
