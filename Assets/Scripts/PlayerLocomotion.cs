using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    Transform cameraObj;
    InputHandler inputHandler;
    Vector3 moveDirection;

    [HideInInspector]
    public Transform myTransform;

    Rigidbody rb;
    public GameObject normalCamera;

    [Header("Stats")]
    [SerializeField]
    float movementSpeed = 5;
    [SerializeField]
    float rotSpeed = 10;

    States currentState;
    public enum States{ Normal, Jump }; 

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
        cameraObj = Camera.main.transform;
        myTransform = transform;
    }

    private void Update() 
    {
        float delta = Time.deltaTime;

        inputHandler.TickInput(delta);

        moveDirection = cameraObj.forward * inputHandler.vertical;
        moveDirection += cameraObj.right * inputHandler.horizontal;
        moveDirection.Normalize();

        float speed = movementSpeed;
        moveDirection *= speed;

        Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);

        rb.velocity = projectedVelocity;

        /*
        float distanciaCercana = Vector3.Distance(transform.position, Attractor.Attractors[0].transform.position);
        int planetaCercano = 0;
        for (int i = 0; i < length; i++)
        {
            float distAux = Vector3.Distance(transform.position, )
        }
        */

        //myTransform.rotation = Quaternion.FromToRotation(transform.up, )

        //HandleRotation(delta);

        #region StateMachine

        switch (currentState)
        {
            default:
            case States.Normal:
            break;

            case States.Jump:
            break;
        }
        #endregion
    }

    #region Movement

    Vector3 normalVector;
    Vector3 targetPosition;

    private void HandleRotation(float delta)
    {
        Vector3 targetDir = Vector3.zero;
        float moveOverride = inputHandler.moveAmount;

        targetDir = cameraObj.forward * inputHandler.vertical;
        targetDir = cameraObj.right * inputHandler.horizontal;

        //se normaliza la direccion
        targetDir.Normalize();
        targetDir.y = 0;
        //si no se apunta a nada, que sea hacia adelante por defecto
        if (targetDir == Vector3.zero)
        {
            targetDir = myTransform.forward;
        }

        float rs = rotSpeed;

        Quaternion tr = Quaternion.LookRotation(targetDir);
        Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta);

        myTransform.rotation = targetRotation;
    }
    #endregion
}
