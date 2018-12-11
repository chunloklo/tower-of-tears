using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour {

    private float max = 0f;
    private float min = 0f;

    public bool North = false;
    public bool East = false;
    public bool South = false;
    public bool West = false;

	void Start () {

        if (North == true)
        {
            max = transform.position.z + 3;
            min = transform.position.z;
        }
        if (East == true)
        {
            max = transform.position.x + 3;
            min = transform.position.x;
        }
        if (South == true)
        {
            max = transform.position.z;
            min = transform.position.z - 3;
        }
        if (West == true)
        {
            max = transform.position.x;
            min = transform.position.x - 3;
        }

	}
	
	// Update is called once per frame
	void Update () {

        if(North == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * 2, max - min) + min);
        }
        if (East == true)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
        }
        if (South == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * 2, max - min) + min);
        }
        if (West == true)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
        }
        
    }
}
