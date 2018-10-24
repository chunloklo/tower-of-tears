using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointListener : MonoBehaviour {

    public GameObject pointLight;
    public GameObject fire;
    private CheckpointActivator ca;

    // Use this for initialization
    void Start()
    {

    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            ca = c.attachedRigidbody.gameObject.GetComponent<CheckpointActivator>();
            if (ca != null)
            {
                Debug.Log("CHARACTER COLLIDED WITH OBJECT");
                //EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);
                ca.ActivateCheckpoint();
                pointLight.SetActive(true);
                fire.SetActive(true);
            }
        }
    }
}
