using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PressurePlateController : MonoBehaviour {

    Animator anim;
    public TrapController[] traps;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        anim.SetBool("Pressed", true);
        for (int i = 0; i < traps.Length; i++)
        {
            traps[i].TrapDisable();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("Pressed", false);
        for (int i = 0; i < traps.Length; i++)
        {
            traps[i].TrapEnable();
        }
    }


}
