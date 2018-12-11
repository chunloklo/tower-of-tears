using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour {
    private Vector3 position;
    private Vector3 endPosition;

    public float length = 1;
    public float speed = 1;

	void Start () {

        position = transform.position;
        endPosition = transform.forward * length + transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.Lerp(position, endPosition, Mathf.PingPong(Time.time * speed, 1));
        
    }
}
