using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GravityBody : MonoBehaviour
{
    List<GravityArea> gravityAreas;
    Rigidbody rb;
    public static float GravityConstant = 800;

    public Vector3 GravityDirection()
    {
        //si no hay gravityAreas, no hay gravedad
        if (gravityAreas.Count == 0) return Vector3.zero;

        //comprobar cual de las en las que estas es mas fuerte/importante
        gravityAreas.Sort((area1, area2) => area1.Priority.CompareTo(area2.Priority));
        return gravityAreas.Last().GetGravityDirection(this).normalized;
        
    }

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        gravityAreas = new List<GravityArea>();
    }

    private void FixedUpdate() 
    {
        rb.AddForce(GravityDirection() * (GravityConstant * Time.fixedDeltaTime), ForceMode.Acceleration);

        Quaternion upRotation = Quaternion.FromToRotation(transform.up, -GravityDirection());
        Quaternion newRotation = Quaternion.Slerp(rb.rotation, upRotation * rb.rotation, Time.fixedDeltaTime * 3f);;
        rb.MoveRotation(newRotation);
    }

    public void AddGravityArea(GravityArea gravityArea)
    {
        gravityAreas.Add(gravityArea);
    }

    public void RemoveGravityArea(GravityArea gravityArea)
    {
        gravityAreas.Remove(gravityArea);
    }
}
