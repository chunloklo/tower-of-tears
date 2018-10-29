using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxController : MonoBehaviour {

    PlayerHealth playerHealth;
    public int fallDamage = 10;
    public float pushBack = 2;

    GameObject player;
    Rigidbody playerRB;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerRB = player.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
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
            playerRB.velocity = offset.normalized * pushBack;
        } else
        {
            player.GetComponent<CheckpointManager>().ResetPosition();
        }
    }
}
