using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyMovementPrediction : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent navMeshAgent;
	private Animator anim;	
	private int attackRadius = 20;
	private int minRadius = 2;
	public GameObject player;
	VelocityReporter velocityScript;
	PlayerHealth playerHealth;

	public enum AIState
	{
		Idle,
		MoveToPlayer
	};

	public AIState aiState;

	void Awake() {
		anim = GetComponent<Animator>();

		if (anim == null)
			Debug.Log("Animator could not be found");

		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();

		if (navMeshAgent == null)
			Debug.Log("NavMeshAgent could not be found");

		player = GameObject.FindGameObjectWithTag ("MovingWaypointCube");

		velocityScript = player.GetComponent<VelocityReporter>();
			
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	// Use this for initialization
	void Start ()
	{
		aiState = AIState.Idle;
	}

	void Update ()
	{
		//state transitions that can happen from any state might happen here
		//such as:
		//if(inView(enemy) && (ammoCount == 0) &&
		// closeEnoughForMeleeAttack(enemy))
		// aiState = AIState.AttackPlayerWithMelee;
		//Assess the current state, possibly deciding to change to a different state

		anim.SetFloat ("vely", navMeshAgent.velocity.magnitude / navMeshAgent.speed);

		Vector3 agentPos = navMeshAgent.transform.position;
		Vector3 targetPos = navMeshAgent.transform.position;
		if (player != null) {
			targetPos = player.transform.position;
		}
		float dist = (targetPos - agentPos).magnitude;
			
		if (playerHealth.isDead) {	
			aiState = AIState.Idle;
		}

//		Debug.Log (playerHealth.currentHealth);
//		Debug.Log (aiState);

		switch (aiState) {
		case AIState.Idle:
			if (dist > attackRadius) {
				anim.SetBool ("Idle", true);
			} else {
				aiState = AIState.MoveToPlayer;
			}
			break;
		case AIState.MoveToPlayer:
			if (dist > minRadius && player != null) {
				navMeshAgent.Resume ();
				moveToPlayer ();
			} else {
//				Debug.Log ("STOP");
				navMeshAgent.Stop ();

			}
			break;
		default:
			break;
		}
	}

	private void moveToPlayer () {
		anim.SetBool ("MoveToPlayer", true);
		Vector3 agentPos = navMeshAgent.transform.position;
		Vector3 targetPos = player.transform.position;
		float dist = (targetPos - agentPos).magnitude;
		float lookAheadT = Mathf.Clamp(dist / navMeshAgent.speed, 0f, 1.5f);
		Vector3 futureTarget = targetPos + lookAheadT * velocityScript.velocity;
//		Vector3 futureTarget = player.transform.position;
		navMeshAgent.SetDestination (futureTarget);
//		Debug.Log (futureTarget);
	}

}
