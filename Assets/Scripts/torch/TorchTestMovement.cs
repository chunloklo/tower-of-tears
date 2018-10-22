using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTestMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(2f*Input.GetAxis("Horizontal") * Time.deltaTime,0f,2f*Input.GetAxis("Vertical") * Time.deltaTime);
	}
}
