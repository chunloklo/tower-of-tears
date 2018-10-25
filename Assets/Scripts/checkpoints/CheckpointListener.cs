using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointListener : MonoBehaviour {

    public GameObject resetTrigger;
    private ResetPlayer resetScript;
    public GameObject pointLight;
    public GameObject fire;
    private CheckpointActivator ca;
    private bool firstTrig;

    // Use this for initialization
    void Start()
    {
        resetScript = resetTrigger.GetComponent<ResetPlayer>();
        firstTrig = false;
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            ca = c.attachedRigidbody.gameObject.GetComponent<CheckpointActivator>();
            if (ca != null)
            {
                if (!firstTrig)
                {
                    Debug.Log(resetTrigger);
                    firstTrig = true;
                    Debug.Log("CHARACTER COLLIDED WITH CHECKPOINT");
                    ca.ActivateCheckpoint();
                    pointLight.SetActive(true);
                    fire.SetActive(true);

                    resetScript.UpdateRespawn();
                }
            }
        }
    }
}
