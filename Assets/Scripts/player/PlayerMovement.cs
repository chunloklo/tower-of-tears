using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
    public float turnSpeed = 5f;

    private bool m_isGrounded;
    private bool m_wasGrounded = false;
    private List<Collider> m_collisions = new List<Collider>();


    Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	void Awake() 
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");


        //Move (v);
        //Turning (h);
		Animating (h, v);
        JumpingAndLanding();

    }

	void Move (float v)
	{
		playerRigidbody.MovePosition (transform.position + transform.forward * v * speed * Time.deltaTime);	
	}

	void Turning(float h)
	{
        Quaternion rotation = Quaternion.AngleAxis(h * turnSpeed, gameObject.transform.up);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * rotation);
        //Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

        //RaycastHit floorHit;

        //if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
        //{
        //	Vector3 playerToMouse = floorHit.point - transform.position;
        //	playerToMouse.y = 0f;

        //	Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
        //	playerRigidbody.MoveRotation (newRotation);
        //}
    }

	void Animating(float h, float v)
	{
        anim.SetFloat("MoveSpeed", v);
        anim.SetBool("Grounded", m_isGrounded);
        //bool walking = h != 0f || v != 0f;
        //anim.SetBool ("IsWalking", walking);
    }

    private void JumpingAndLanding()
    {

        if (m_isGrounded && Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            anim.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            anim.SetTrigger("Jump");
        }

        m_wasGrounded = m_isGrounded;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }
}
