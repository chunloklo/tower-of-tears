using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour {
    
    public int fallDamage = 1;
    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;

    CheckpointManager cm;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        cm = player.GetComponent<CheckpointManager>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void Update()
    {
        if (playerInRange)
        {
            ResetPlayerPosition();
        }
    }

    void ResetPlayerPosition()
    {
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(fallDamage);
        }

        cm.ResetPosition();
        playerInRange = false;
    }
}
