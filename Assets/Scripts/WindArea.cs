using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public Vector3 direction;
    Vector3 directionSave;

    public float strenght;

    Rigidbody playerRb;

    public int myId;

    private void OnEnable()
    {
        //EventManager.OnPresionClose += Desactivate;
        //EventManager.OnPresionOpen += Activate;
    }

    private void OnDisable()
    {
        //EventManager.OnPresionClose -= Desactivate;
        //EventManager.OnPresionOpen -= Activate;
    }

    void Start()
    {
        directionSave = direction;
    }

    void Desactivate(int id)
    {
        Debug.Log("desactivate");
        if (myId == id)
        {
            direction = Vector3.zero;
        }
    }

    void Activate(int id)
    {
        Debug.Log("activate");
        if (myId == id)
        {
            direction = directionSave;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //pillo el rb y le aplico la fuerza
            playerRb = other.gameObject.GetComponent<Rigidbody>();
            playerRb.AddForce(direction * strenght, ForceMode.Impulse);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //reset
            playerRb = other.gameObject.GetComponent<Rigidbody>();
            playerRb.AddForce(Vector3.zero);
        }
    }
}
