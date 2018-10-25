using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointActivator : MonoBehaviour {

    public bool activatedCheckpoint_1;

	// Use this for initialization
	void Start () {
        activatedCheckpoint_1 = false;
	}
	
	public void ActivateCheckpoint()
    {
        activatedCheckpoint_1 = true;
    }
}
