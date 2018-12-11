using UnityEngine;
using System.Collections.Generic;


[RequireComponent(typeof(GroundCheck))]
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

    public float jumpForce;

    private List<Collider> groundColliders = new List<Collider>();
    private bool isGrounded;

    public GroundCheck groundCheck;

    public Vector3 additionalDisplacement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        groundCheck = GetComponent<GroundCheck>();
        prevInput = GetInputVector();
        prevSpeed = 0;
        additionalDisplacement = new Vector3(0, 0, 0);


    }

    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * rb.mass * 2);
        rb.angularVelocity = new Vector3(0, 0, 0);
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

        Vector3 targetVector = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up) * camForward;
        float angleBetween = Vector3.Angle(targetVector, gameObject.transform.forward);

        gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward, targetVector, rotationLerp * Time.deltaTime);

        return targetVector;

    }

    void MovementUpdate(Vector2 inputVec, Vector3 targetVector)
    {
        float moveSpeed = Mathf.Lerp(prevSpeed, speed * inputVec.magnitude, speedLerp * Time.deltaTime);

        prevSpeed = moveSpeed;
        rb.MovePosition(rb.position + targetVector * moveSpeed * Time.deltaTime + additionalDisplacement);
        //Debug.Log(string.Format("Speed: {0}", moveSpeed / speed));
        anim.SetFloat("forward", moveSpeed / speed);
        //anim.SetFloat("speed", moveSpeed / speed);
    }

    void JumpUpdate()
    {
        anim.SetBool("isGrounded", groundCheck.IsGrounded());
        if (Input.GetButtonDown("Jump") && groundCheck.IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!groundColliders.Contains(collision.collider))
                {
                    groundColliders.Add(collision.collider);
                }
                isGrounded = true;
            }
        }
    }

}
