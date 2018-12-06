using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineBrainController : MonoBehaviour {

    public ICinemachineCamera ActiveVirtualCamera
    { get;
    }

    // Use this for initialization
    void Start () {
        Debug.Log(ActiveVirtualCamera);        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
