using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
    public float timeBetweenRangeAttacks = 5.0f;
    public int rangeAttackDamage = 10;

    private float internalTimer = 2.0f;

    GameObject rangeBallOff;
    GameObject rangeBallOn;
	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    private Vector3 playerPosition;
    private Vector3 BallOffPosition;

	bool playerInRange;
	float timer;
    float rangeTimer;
    float activeTimer;
    bool isSpawnedOff = false;
    bool isSpawnedOn = false;


	void Awake ()
	{
        rangeBallOn = GameObject.FindGameObjectWithTag("RangeBallOn");
        rangeBallOff = GameObject.FindGameObjectWithTag("RangeBallOff");
        rangeBallOff.SetActive(false);
        rangeBallOn.SetActive(false);
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent<EnemyHealth>();
		anim = GetComponent <Animator> ();
	}


	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
//			Debug.Log ("HIT");
			playerInRange = true;
		}

	}


	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}


	void Update ()
	{
		timer += Time.deltaTime;
        rangeTimer += Time.deltaTime;
        if (isSpawnedOff)
        {
            activeTimer += Time.deltaTime;
            BallExist();
        }
        if (isSpawnedOn)
        {
            activeTimer += Time.deltaTime;
            DamageBallExist();
        }

		if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
		{
			Attack ();
		}
        if(rangeTimer >= timeBetweenRangeAttacks && !playerInRange && enemyHealth.currentHealth > 0)
        {
            RangedAttack();
        }
		if(playerHealth.currentHealth <= 0)
		{
			Destroy (player);
//			Debug.Log ("PLAYER DEAD");
		}
	}


	void Attack ()
	{
		timer = 0f;

		if(playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage (attackDamage);
			Debug.Log ("ATTACK");
			anim.SetTrigger ("Attack");
		}
	}

    void RangedAttack ()
    {
        rangeTimer = 0f;
        if(playerHealth.currentHealth > 0)
        {
            isSpawnedOff = true;
            playerPosition = player.transform.position;
            Debug.Log ("RANGE ATTACK");
            anim.SetTrigger ("Attack");
        }
    }
    
    void BallExist()
    {
        rangeBallOff.SetActive(true);
        rangeBallOff.transform.position = playerPosition;
        BallOffPosition = rangeBallOff.transform.position;
        if (activeTimer > internalTimer)
        {
            isSpawnedOff = false;
            rangeBallOff.SetActive(false);
            activeTimer = 0f;
            
            isSpawnedOn = true;
            DamageBallExist();
        }
    }

    void DamageBallExist()
    {
        rangeBallOn.SetActive(true);
        rangeBallOn.transform.position = BallOffPosition;
        if (player.transform.position == rangeBallOn.transform.position)
        {
            playerHealth.TakeDamage(rangeAttackDamage);
        }
        if (activeTimer > internalTimer)
        {
            isSpawnedOn = false;
            rangeBallOn.SetActive(false);
            activeTimer = 0f;
        }
    }
}
