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

    public float prevSpeed;
    private float speedLerp = 10f;
    private float rotationLerp = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        prevInput = GetInputVector();
        prevSpeed = 0;


    }

    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * rb.mass * 2);
    }

    void Update()
	{
        Vector2 inputVec = GetInputVector();

        Vector3 targetVector = transform.forward;
        if (inputVec.magnitude > 0)
        {
            targetVector = RotationUpdate(inputVec);

        }
        MovementUpdate(inputVec, targetVector);

        JumpUpdate();

        prevInput = inputVec;

    }

    Vector2 GetInputVector()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 inputVec = new Vector2(h, v);
        if (inputVec.magnitude > 1)
        {
            inputVec = inputVec.normalized * 1.0f;
        }

        return inputVec;
    }

    Vector3 RotationUpdate(Vector2 inputVec)
    {
        Transform camera = Camera.main.transform;
        float angle = Mathf.Atan2(inputVec.x, inputVec.y);

        Vector3 camForward = new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z).normalized;

        Debug.Log(angle);
        Vector3 targetVector = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up) * camForward;
        float angleBetween = Vector3.Angle(targetVector, gameObject.transform.forward);

        gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward, targetVector, rotationLerp * Time.deltaTime);

        return targetVector;

    }

    void MovementUpdate(Vector2 inputVec, Vector3 targetVector)
    {

        //Debug.Log(string.Format("Prev speed: {0} Target Speed {1} Actual Speed {2}", prevSpeed, speed * inputVec.magnitude, moveSpeed));

        //float epsilon = 45f;
        //Debug.Log("Angle: " + angleError);
        //if (angleError > epsilon)
        //{
        //    return;
        //}

        float moveSpeed = Mathf.Lerp(prevSpeed, speed * inputVec.magnitude, speedLerp * Time.deltaTime);

        prevSpeed = moveSpeed;
        rb.MovePosition(rb.position + targetVector * moveSpeed * Time.deltaTime);
        //Debug.Log(string.Format("Speed: {0}", moveSpeed / speed));
        anim.SetFloat("forward", moveSpeed / speed);
        //anim.SetFloat("speed", moveSpeed / speed);
    }

    void JumpUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }
    }
}
