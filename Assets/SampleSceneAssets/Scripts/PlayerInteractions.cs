using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//REFERENCIA PARA LAS INTERACCIONES DE LAS ZONAS DE GRAVEDAD, SE USARÁ PARTE, ES UN COPYPASTE DE UNO QUE 
//YA HICE SIN AUN IMPLEMENTAR A LAS FUNCIONALIDADES DE ESTE JUEGO


public class PlayerInteractions : MonoBehaviour
{
    Rigidbody rb;

    public bool onWindArea;
    GameObject windAreaGO;
    WindArea windAreaScr;
    
    float timer;
    bool timerOn;

    bool gliding;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        Debug.Log(onWindArea);
        if (timerOn && onWindArea)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            TimerOff();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Aire"))
        {
            Debug.Log("en el aire");
            Debug.LogWarning(RigidBodyMov.rbMov.state);
            gliding = true;
            Debug.Log("viento");
            windAreaGO = other.gameObject;
            windAreaScr = windAreaGO.GetComponent<WindArea>();
            onWindArea = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Aire"))
        {
            gliding = false;
            Debug.LogError(gliding + " gliding false");
            timerOn = true;
        }
    }

    void TimerOff()
    {
        if (timer >= 0.2f)
        {
            timerOn = false;
            timer = 0;
            onWindArea = false;
        }
        Debug.Log(timerOn);
    }

    private void FixedUpdate() 
    {
        if (onWindArea)
        {
            rb.AddForce(windAreaScr.direction * windAreaScr.strenght);
        }
    }
}
