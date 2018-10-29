using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraController : MonoBehaviour {

    public GameObject player;

    public float moveTightness = 0.5f;
    public float moveHitTightness = 10.0f;
    public float lookTightness = 2.0f;

    private Vector3 offset;

    private float camErrorThreshold = 1;
    private Vector3 lookAtPosition;
    private Vector3 mouseOffset;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float speedH = 5.0f;
    public float speedV = 5.0f;

    // Use this for initialization
    void Start () {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //offset = transform.position - player.transform.position;
        offset = new Vector3(0, 2, -5);
        lookAtPosition = player.transform.position;
        mouseOffset = offset;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        //rotations based off mouse movement
        if (Input.GetMouseButton(0))
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

        }

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        Vector3 rotateOffset = Quaternion.Euler(pitch, yaw, 0) * offset;
        transform.LookAt(player.transform.position);

        Vector3 target = player.transform.position + rotateOffset;

        transform.position = target;


        //float camError = Mathf.Pow(1.1f, Vector3.Magnitude(transform.position - target));
        //Vector3 lerpTarget = Vector3.Lerp(transform.position, target, camError * moveTightness * Time.deltaTime);

        //Vector3 rayCastOrigin = player.transform.position + new Vector3(0, offset.y, 0);

        //Vector3 relativePos = lerpTarget - rayCastOrigin;
        //RaycastHit hit;
        //if (Physics.Raycast(rayCastOrigin, relativePos, out hit, relativePos.magnitude, 1))
        //{
        //    Debug.Log("HIT");
        //    target = hit.point;
        //    lerpTarget = Vector3.Lerp(transform.position, target, moveHitTightness * Time.deltaTime);
        //}

        //transform.position = lerpTarget;



        ////transform.position = lerpTarget;
        ////if (camError > camErrorThreshold)
        ////{
        ////    transform.position = Vector3.Lerp(transform.position, player.transform.TransformPoint(offset), 0.1f);
        ////}
        ////else
        ////{
        ////    transform.position = Vector3.Lerp(transform.position, player.transform.TransformPoint(offset), 0.01f);
        ////}

        //float lookError = Mathf.Pow(1.1f, Vector3.Magnitude(player.transform.position - lookAtPosition));
        //Vector3 lookTarget = Vector3.Lerp(lookAtPosition, player.transform.position, lookError * lookTightness * Time.deltaTime);
        //lookAtPosition = lookTarget;

        //transform.LookAt(lookTarget);
    }
}
