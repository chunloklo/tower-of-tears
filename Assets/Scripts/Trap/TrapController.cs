using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TrapController : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TrapEnable()
    {
        anim.SetBool("Active", true);
    }

    public void TrapDisable()
    {
        anim.SetBool("Active", false);
    }
}
