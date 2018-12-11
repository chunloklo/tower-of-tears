using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AutoRotater : MonoBehaviour {

    public Rigidbody rb;
    public RotateChild rc;
    public float speed = 1;
    // Use this for initialization

    public float maxAngle;
    public float currentAngle = 0;

	void Start () {
        rb = GetComponent<Rigidbody>();
        rc = GetComponent<RotateChild>();
    }

    private void LateUpdate()
    {
        if (rc != null && !rc.playerContact)
        {
            Debug.Log("Rotating");
            rb.angularVelocity = new Vector3(0, speed, 0);
            //Quaternion rotation = Quaternion.Euler(0, speed * 180 / Mathf.PI * Time.deltaTime, 0);
            //rb.transform.localRotation *= rotation;
        }

        if (rc == null)
        {
            currentAngle += speed * 180 / Mathf.PI * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(0, speed * 180 / Mathf.PI * Time.deltaTime, 0);
            rb.transform.localRotation *= rotation;

            if (maxAngle != -1 && Mathf.Abs(currentAngle) > maxAngle)
            {
                speed = -speed;
                currentAngle = 0;
            }

        }
    }

}
