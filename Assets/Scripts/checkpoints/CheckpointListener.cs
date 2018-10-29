using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointListener : MonoBehaviour {

    public GameObject resetTrigger;
    public GameObject pointLight;
    public GameObject fire;
    private CheckpointManager cm;
    private bool firstTrig;

    // Use this for initialization
    void Start()
    {
        firstTrig = false;
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            cm = c.attachedRigidbody.gameObject.GetComponent<CheckpointManager>();
            if (cm != null)
            {
                if (!firstTrig)
                {
                    Debug.Log(resetTrigger);
                    firstTrig = true;
                    Debug.Log("CHARACTER COLLIDED WITH CHECKPOINT");
                    cm.UpdateCheckpoint(c.gameObject.transform.position, c.gameObject.transform.rotation);
                    pointLight.SetActive(true);
                    fire.SetActive(true);
                }
            }
        }
    }
}
