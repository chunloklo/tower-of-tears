using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChild : MonoBehaviour {


    public TowerRotater parent;
	// Use this for initialization
	void Start () {
        parent = transform.parent.GetComponent<TowerRotater>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        parent.StopRotation();
    }
}
