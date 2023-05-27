using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;
    [SerializeField] Animator anim;

    float groundCheckRadius = 0.3f;
    float speed = 8;
    float turnSpeed = 1800f;
    float jumpForce = 300f;

    float h, v;

    Rigidbody rb;
    Vector3 direction;

    GravityBody gravityBodyScr;

    #region Jetpack
    [Header("JetPack")]
    [SerializeField] float maxFuel = 4f;
    [SerializeField] float force = 0.5f;
    [SerializeField] ParticleSystem effect;
    public float currentFuel;

    #endregion

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        gravityBodyScr = GetComponent<GravityBody>();
        currentFuel = maxFuel;
    }

    private void Update() 
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        direction = new Vector3(h, 0, v).normalized;
        bool onGround = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(-gravityBodyScr.GravityDirection() * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump");
            
        }

        if (Input.GetKey(KeyCode.Space) && !onGround && currentFuel > 0f)
            {
                currentFuel -= Time.deltaTime;
                rb.AddForce(rb.transform.up * force, ForceMode.Impulse);
                //effect.Play();
            }
            else if (onGround && currentFuel < maxFuel)
            {
                currentFuel += Time.deltaTime;
                //effect.Stop();
            }
            else
            {
                //effect.Stop();
                anim.SetTrigger("Fall");
            }

            if (onGround)
            {
                anim.SetTrigger("Fall");
            }
    }

    private void FixedUpdate() 
    {
        bool isRunning = direction.magnitude > 0.1f;

        if(isRunning)
        {
            anim.SetBool("Walking", true);
            Vector3 directionUp = transform.forward * direction.z;
            Vector3 directionRight = transform.right * direction.x;
            Vector3 directionAux = directionUp + directionRight;
            rb.MovePosition(rb.position + directionAux * (speed * Time.fixedDeltaTime));

            Quaternion rightDirection = Quaternion.Euler(0f, direction.x * (turnSpeed * Time.fixedDeltaTime), 0f);
            Quaternion newRotation = Quaternion.Slerp(rb.rotation, rb.rotation * rightDirection, Time.fixedDeltaTime * 2f);
            rb.MoveRotation(newRotation);
        }
        else 
        {
            anim.SetBool("Walking", false);
        }
    }
}
