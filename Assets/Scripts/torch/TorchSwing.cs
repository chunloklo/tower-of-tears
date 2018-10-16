using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSwing : MonoBehaviour {

	Animator anim;

	void Start() {
		anim = GetComponent<Animator> ();
		anim.SetTrigger("TorchSpin");
	}

//	void OnTriggerEnter(Collider c) {
//		anim.SetTrigger("TorchSpin");
//	}

//	void OnTriggerExit(Collider c) {
//		anim.Play("Idle");
//	}
}
