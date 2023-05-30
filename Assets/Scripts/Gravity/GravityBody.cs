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

        /* Intento de hacerlo respecto a la distancia entre una zona y otra
        float nearDist = Vector3.Distance(transform.position, gravityAreas[0].transform.position);
        int nearArea = 0;
        for (int i = 0; i < gravityAreas.Count; i++)
        {
            float distAux = Vector3.Distance(transform.position, gravityAreas[i].transform.position);
            if(distAux < nearDist)
            {
                nearDist = distAux;
                nearArea = i;
            }
        }
        */
    }

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        gravityAreas = new List<GravityArea>();
    }

    private void FixedUpdate() 
    {
        //aplicar la fuerza
        rb.AddForce(GravityDirection() * (GravityConstant * Time.fixedDeltaTime), ForceMode.Acceleration);

        //rotacion segun el punto desde el que se de la gravedad al cuerpo segun su posicion
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, -GravityDirection()) * transform.rotation;
        float smooth = 5;

        //Suavizado rotacion
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
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
