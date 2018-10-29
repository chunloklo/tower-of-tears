using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

    public bool activatedCheckpoint_1;
    public Vector3 checkpointPos;
    Quaternion checkpointRotation = new Quaternion(0, 0, 0, 1);


    // Use this for initialization
    void Start () {
        activatedCheckpoint_1 = false;
	}
	
	public void ActivateCheckpoint()
    {
        activatedCheckpoint_1 = true;
    }

    public void ResetPosition()
    {
        gameObject.transform.position = checkpointPos;
        gameObject.transform.rotation = checkpointRotation;
    }

    public void UpdateCheckpoint(Vector3 pos, Quaternion rot)
    {
        checkpointPos = pos;
        checkpointRotation = rot;
    }

}
