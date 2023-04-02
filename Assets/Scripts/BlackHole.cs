using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public int triggerId;

    [HideInInspector] 
    public GameObject obj;

    [HideInInspector]
    public Vector3 objInnercia;

    public static List<BlackHole> BlackHoles;


    private void OnEnable() 
    {
        if (BlackHoles == null)
        {
            BlackHoles = new List<BlackHole>();
        }

        BlackHoles.Add(this);
    }

    private void OnDisable() 
    {
        BlackHoles.Remove(this);        
    }

    private void OnTriggerEnter(Collider other) 
    {
        EventManager.BlackHoleTriggerEnter(triggerId);
        obj = other.gameObject;

        Rigidbody objRb = obj.GetComponent<Rigidbody>();
        objInnercia = objRb.velocity;
    }
}
