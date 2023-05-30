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

    bool onGround;

    Rigidbody rb;
    Vector3 direction;

    GravityBody gravityBodyScr;

    #region Jetpack
    [Header("JetPack")]
    [SerializeField] float maxFuel = 4f;
    [SerializeField] float force = 20f;
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

        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update() 
    {
        Directions();
        JetPack();

        onGround = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(-gravityBodyScr.GravityDirection() * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump");
        }

        if (onGround)
        {
            anim.SetTrigger("Fall");
            Debug.Log("caer");
        }

    }

    void Directions()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        direction = new Vector3(h, 0, v).normalized;
    }

    void JetPack()
    {
        #region Up
        if (Input.GetKey(KeyCode.Space) && !onGround && currentFuel > 0f)
        {
            currentFuel -= Time.deltaTime;
            rb.AddForce(rb.transform.up * force, ForceMode.Acceleration);
            //effect.Play();
            Debug.Log("volar");
        }
        else if (onGround && currentFuel < maxFuel)
        {
            currentFuel += Time.deltaTime;
            //effect.Stop();
            Debug.Log("recargando");
        }
        else
        {
            //effect.Stop();
            anim.SetTrigger("Fall");
        }
        
        #endregion

        #region Down
        if (Input.GetKey(KeyCode.LeftShift) && !onGround && currentFuel > 0f)
        {
            currentFuel -= Time.deltaTime;
            rb.AddForce(-rb.transform.up * force, ForceMode.Acceleration);
            //effect.Play();
            Debug.Log("volar");
        }
        else if (onGround && currentFuel < maxFuel)
        {
            currentFuel += Time.deltaTime;
            //effect.Stop();
            Debug.Log("recargando");
        }
        else
        {
            //effect.Stop();
            anim.SetTrigger("Fall");
        }

        #endregion
    }

    private void FixedUpdate() 
    {
        bool isRunning = direction.magnitude > 0.1f;

        if(isRunning)
        {
            #region  Movement
            Vector3 directionUp = transform.forward * direction.z;
            Vector3 directionRight = transform.right * direction.x;
            Vector3 directionAux = directionUp + directionRight;
            rb.MovePosition(rb.position + directionAux * (speed * Time.fixedDeltaTime));

            #endregion

            #region Rotation
            Quaternion toRotation = Quaternion.FromToRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 2 * Time.fixedDeltaTime);

            #endregion

            if (onGround) anim.SetBool("Walking", true);
        }
        else 
        {
            anim.SetBool("Walking", false);
        }
    }
}
