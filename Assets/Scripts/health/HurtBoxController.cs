using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxController : MonoBehaviour {

    PlayerHealth playerHealth;
    public int fallDamage = 1;
    public float pushBack = 1000;

    public GameObject player;
    public Rigidbody playerRB;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerRB = player.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        //playerRB.velocity = new Vector3(1, 0, 0);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
        if (playerHealth.playerInvulRemaining > 0) {
            return;
        }
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(fallDamage);
            Vector3 offset = player.transform.position - gameObject.transform.position;
            offset.y = .1f;
            //offset = Vector3.RotateTowards(offset.normalized, new Vector3(0, 1, 0), Mathf.PI / 18, 0.0f);
            Debug.Log(offset.normalized * pushBack);
            playerRB.AddExplosionForce(pushBack, gameObject.transform.position, 10f, 1f, ForceMode.Impulse);
        } else
        {
            player.GetComponent<CheckpointManager>().ResetPosition();
        }
    }
}
