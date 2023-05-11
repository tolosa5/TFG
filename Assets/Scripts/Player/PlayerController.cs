using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;
    Transform cam;
    [SerializeField] Animator animator;
    
    float groundCheckRadius = 0.3f;
    float speed = 8;
    float turnSpeed = 1500f;
    float jumpForce = 500f;

    Rigidbody rb;
    Vector3 direction;
    float h;
    float v;

    //GravityBody gravityBody;
    
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        //gravityBody = transform.GetComponent<GravityBody>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        direction = new Vector3(h, 0f, v).normalized;

        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
        animator.SetBool("isJumping", !isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //rb.AddForce(-gravityBody.GravityDirection * jumpForce, ForceMode.Impulse);
        }
    }
    
    void FixedUpdate()
    {
        //si direction es diferente a 0, es que esta moviendose
        bool isRunning = direction.magnitude > 0.1f;
        
        if (isRunning)
        {
            Vector3 directionAux = transform.forward * direction.z;
            rb.MovePosition(rb.position + direction * (speed * Time.fixedDeltaTime));
            
            Quaternion rightDirection = Quaternion.Euler(0f, direction.x * (turnSpeed * Time.fixedDeltaTime), 0f);
            Quaternion newRotation = Quaternion.Slerp(rb.rotation, rb.rotation * rightDirection, Time.fixedDeltaTime * 3f);
            rb.MoveRotation(newRotation);
        }

        animator.SetBool("isRunning", isRunning);
    }
}
