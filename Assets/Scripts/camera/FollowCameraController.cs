using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraController : MonoBehaviour {

    public GameObject player;

    public float tightness = 0.1f;

    private Vector3 offset;
    private Vector3 lookAtPosition;
    private Vector3 mouseOffset;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float speedH = 5.0f;
    public float speedV = 5.0f;

    public bool invert;

    public bool disabled;

    private float distance = 1;

    // Use this for initialization
    void Start () {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //offset = transform.position - player.transform.position;
        offset = new Vector3(0, 2, -5);
        player = GameObject.FindGameObjectWithTag("Player");
        lookAtPosition = player.transform.position;
        mouseOffset = offset;
        Cursor.visible = false;
        disabled = false;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (disabled)
        {
            return;
        }
        //rotations based off mouse movement
        if(true)
        //if (Input.GetMouseButton(1))
        {
            if (invert)
            {
                yaw -= speedH * Input.GetAxis("Mouse X");
                pitch += speedV * Input.GetAxis("Mouse Y");
            }
            else
            {
                yaw += speedH * Input.GetAxis("Mouse X");
                pitch -= speedV * Input.GetAxis("Mouse Y");
            }
        }
        

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        Vector3 rotateOffset = Quaternion.Euler(pitch, yaw, 0) * offset;
        transform.LookAt(player.transform.position);

        Vector3 target = player.transform.position + rotateOffset;


        Vector3 rayCastOrigin = player.transform.position + new Vector3(0, offset.y, 0);

        Vector3 relativePos = target - rayCastOrigin;
        RaycastHit hit;
        if (Physics.Raycast(rayCastOrigin, relativePos, out hit, relativePos.magnitude, 1))
        {
            Debug.Log("HIT");
            target = hit.point - relativePos.normalized * 0.1f;
        }

        transform.position = Vector3.Lerp(gameObject.transform.position, target, tightness);
    }
}
