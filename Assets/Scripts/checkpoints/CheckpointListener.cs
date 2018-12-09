using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointListener : MonoBehaviour {

    public GameObject lampPost_1;
    public Material lampActive;
    public Material lampInactive;
    private CheckpointManager cm;
    private bool firstTrig;

    // Use this for initialization
    void Start()
    {
        firstTrig = false;
        lampPost_1.GetComponent<MeshRenderer>().material = lampInactive;
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null && c.tag == "Player")
        {
            cm = c.attachedRigidbody.gameObject.GetComponent<CheckpointManager>();
            if (cm != null)
            {
                if (!firstTrig)
                {
                    firstTrig = true;
                    Debug.Log("CHARACTER COLLIDED WITH CHECKPOINT");
                    cm.UpdateCheckpoint(c.gameObject.transform.position, c.gameObject.transform.rotation);
                    lampPost_1.GetComponent<MeshRenderer>().material = lampActive;
                    EventManager.TriggerEvent<CheckpointActivateEvent, Vector3>(lampPost_1.transform.position);
                }
            }
        }
    }
}
