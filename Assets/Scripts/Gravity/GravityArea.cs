using UnityEngine;

//abstract class para permitir la existencia de una funcion sin cuerpo
public abstract class GravityArea : MonoBehaviour
{
    [SerializeField] int priority;
    public int Priority => priority;

    private void Start() 
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireSphere(Vector3.zero, .5f);
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
