using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;
    Animator anim;

    float groundCheckRadius = 0.3f;
    float speed = 8;
    float turnSpeed = 1500f;
    float jumpForce = 500f;

    float h, v;

    Rigidbody rb;
    Vector3 direction;

    GravityBody gravityBodyScr;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        gravityBodyScr = GetComponent<GravityBody>();   
    }

    private void Update() 
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        direction = new Vector3(h, 0, v);
        bool onGround = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(gravityBodyScr.GravityDirection() * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate() 
    {
        bool isRunning = direction.magnitude > 0.1f;

        if(isRunning)
        {
            Vector3 directionAux = transform.forward * direction.z;
            rb.MovePosition(rb.position + direction * (speed * Time.fixedDeltaTime));

            Quaternion rightDirection = Quaternion.Euler(0f, direction.x * (turnSpeed * Time.fixedDeltaTime), 0f);
            Quaternion newRotation = Quaternion.Slerp(rb.rotation, rb.rotation * rightDirection, Time.fixedDeltaTime * 3f);;
            rb.MoveRotation(newRotation);
        }    
    }
}
