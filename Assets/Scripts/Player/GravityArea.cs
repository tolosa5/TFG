using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract class para permitir la existencia del GravityDirecion
public abstract class GravityArea : MonoBehaviour
{
    [SerializeField] int priority;
    public int Priority => priority;

    private void Start() 
    {
        GetComponent<Collider>().isTrigger = true;
    }

    public abstract Vector3 GetGravityDirection(GravityBody gravityBody);

    private void OnTriggerEnter(Collider other) 
    {
        if (other.TryGetComponent(out GravityBody gravityBody))
        {
            gravityBody.AddGravityArea(this);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.TryGetComponent(out GravityBody gravityBody))
        {
            gravityBody.RemoveGravityArea(this);
        }
    }
}
