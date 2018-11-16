using UnityEngine;
using System.Collections.Generic;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

    public Rigidbody rb;
    public Animator anim;

    public Vector2 prevInput;
    private float lerpFactor = 0.9f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        prevInput = GetInputVector();
        
    }

    void Update()
	{
        Vector2 inputVec = GetInputVector();

        inputVec = Vector2.Lerp(prevInput, inputVec, 0.8f);

        if (inputVec.magnitude > 0)
        {
            Vector3 forwardTarget = RotationUpdate(inputVec);
            MovementUpdate(inputVec, forwardTarget);
        }
        
        if (inputVec.magnitude < .1)
        {
            anim.SetBool("forward", false);
        }

        prevInput = inputVec;

    }

    Vector2 GetInputVector()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 inputVec = new Vector2(h, v);
        if (inputVec.magnitude > .5)
        {
            inputVec = inputVec.normalized * 0.5f;
        }

        return inputVec;
    }

    Vector3 RotationUpdate(Vector2 inputVec)
    {
        Transform camera = Camera.main.transform;
        float angle = Mathf.Atan2(inputVec.x, inputVec.y);

        Vector3 camForward = camera.transform.forward;
        camForward.y = 0;

        Debug.Log(angle);
        Vector3 targetVector = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up) * camForward;

        gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward, targetVector, 0.5f);
        return targetVector.normalized;

    }

    void MovementUpdate(Vector2 inputVec, Vector3 targetForward)
    {
        float forwardAngle = Mathf.Atan2(gameObject.transform.forward.z, gameObject.transform.forward.x);
        float targetAngle = Mathf.Atan2(targetForward.z, targetForward.x);
        float epsilon = .1f;
        if (Mathf.Abs(forwardAngle - targetAngle) < epsilon)
        {
            float moveSpeed = speed * inputVec.magnitude;
            rb.MovePosition(rb.position + targetForward * moveSpeed * Time.deltaTime);
            anim.SetBool("forward", true);

            anim.SetFloat("speed", moveSpeed / speed * 0.8f);
        } 
    }
}
