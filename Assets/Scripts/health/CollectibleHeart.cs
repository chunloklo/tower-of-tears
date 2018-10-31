using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHeart : MonoBehaviour {

    public GameObject player;
    public GameObject heart;
    public int heartHealthVal = 1;
    private HeartCollector hc;
    private PlayerHealth ph;
    private Animator anim;

    private bool given;

    // Use this for initialization
    void Start () {
        given = false;
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.Log("Animator could not be found");
        }
        ph = player.GetComponent<PlayerHealth>();
    }

    public void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null && c.tag == "Player")
        {
            hc = c.attachedRigidbody.gameObject.GetComponent<HeartCollector>();
            if (hc != null && !given && ph.currentHealth < ph.startingHealth)
            {
                given = true;
                EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);
                hc.ReceiveHeart();
                Destroy(heart);
                Destroy(this.gameObject);
                ph.ReceiveHealth(heartHealthVal);
            }
        }
    }
}
