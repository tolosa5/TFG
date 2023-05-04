using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRain : MonoBehaviour
{
    Rigidbody rb;
    
    Vector3 direction;
    float velocity;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();

        direction = new Vector3 (Random.Range(-45, 45), Random.Range(-45, 45), Random.Range(-45, 45));
        velocity = Random.Range(2f, 4f);
    }

    private void FixedUpdate() 
    {
        rb.AddForce(direction * velocity, ForceMode.Impulse);
    }
}
