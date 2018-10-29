using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TrapEnable()
    {
        
    }

    public void TrapDisable()
    {
        gameObject.GetComponent<Animation>().Play();
    }
}
