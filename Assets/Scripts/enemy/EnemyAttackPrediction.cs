using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class EnemyAttackPrediction : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent navMeshAgent;
	private Animator anim;	
	private int attackRadius = 20;
	public GameObject player;
	VelocityReporter velocityScript;

	public enum AIState
	{
		Idle,
		Attack
	};

	public AIState aiState;

	void Awake() {
		anim = GetComponent<Animator>();

		if (anim == null)
			Debug.Log("Animator could not be found");

		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();

		if (navMeshAgent == null)
			Debug.Log("NavMeshAgent could not be found");

		player = GameObject.FindWithTag ("MovingWaypointCube");

		velocityScript = player.GetComponent<VelocityReporter>();
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

		switch (aiState) {
		case AIState.Idle:
			Vector3 agentPos = navMeshAgent.transform.position;
			Vector3 targetPos = player.transform.position;
			float dist = (targetPos - agentPos).magnitude;
			if (dist > attackRadius) {
				anim.SetBool ("Idle 0", true);
			} else {
				aiState = AIState.Attack;
			}
			break;
		case AIState.Attack:
			attack ();
			break;
		default:
			break;
		}
	}

	private void attack () {
		anim.SetBool ("Attack 0", true);
		Vector3 agentPos = navMeshAgent.transform.position;
		Vector3 targetPos = player.transform.position;
		float dist = (targetPos - agentPos).magnitude;
		float lookAheadT = Mathf.Clamp(dist / navMeshAgent.speed, 0f, 1.5f);
		Vector3 futureTarget = targetPos + lookAheadT * velocityScript.velocity;
		navMeshAgent.SetDestination (futureTarget);
	}
}
