using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour {
    
    public int fallDamage = 10;
    public GameObject checkpoint1;

    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;

    Vector3 startingCoord = new Vector3(-0.18f, 0.70f, -6.6f);
    Vector3 checkpoint_1_coord;
    Vector3 currentCoord;
    Quaternion startingRotation = new Quaternion(0,0,0,1);


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("MovingWaypointCube");
        playerHealth = player.GetComponent<PlayerHealth>();
        currentCoord = startingCoord;

        checkpoint_1_coord = checkpoint1.transform.position;
        checkpoint_1_coord.y += 0.7f;

        Debug.Log("checkpoint_1_coord: " + checkpoint_1_coord);
        Debug.Log("startingCoord: " + startingCoord);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
        Debug.Log("currentCoord: " + currentCoord);
    }


    void Update()
    {

        if (playerInRange)
        {
            ResetPlayerPosition();
        }
    }

    public void UpdateRespawn()
    {
        currentCoord = checkpoint_1_coord;
    }


    void ResetPlayerPosition()
    {
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(fallDamage);
        }

        player.transform.position = currentCoord;
        player.transform.rotation = startingRotation;



        playerInRange = false;
    }
}
