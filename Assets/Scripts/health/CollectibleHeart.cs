using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHeart : MonoBehaviour {

    public GameObject heart;
    private HeartCollector hc;
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        if (anim == null)
            Debug.Log("Animator could not be found");
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            hc = c.attachedRigidbody.gameObject.GetComponent<HeartCollector>();
            if (hc != null)
            {
                Debug.Log("CHARACTER COLLIDED WITH OBJECT");
                EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);
                hc.ReceiveBall();
                Destroy(heart);
                Destroy(this.gameObject);
            }
        }
    }
}
