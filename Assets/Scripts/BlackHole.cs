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

    Rigidbody objRb;

    public static List<BlackHole> BlackHoles;
    [SerializeField] GameObject whiteHole;


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
        Debug.Log("entrando");

        obj.transform.position = whiteHole.transform.position;

        objRb = obj.GetComponent<Rigidbody>();
        objRb.velocity /= 5;

        StartCoroutine(DragWait());
    }

    IEnumerator DragWait()
    {
        objRb.drag = 1;
        yield return new WaitForSeconds(0.5f);
        objRb.drag = 0;
    }
}
