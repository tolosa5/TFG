using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody rb;
    public static List<Attractor> Attractors;
    const float G = 66.74f;

    private void OnEnable() 
    {
        //al ser estatica la lista, pertenece a la clase, a todos los atractores
        if (Attractors == null)
        {
            //se crea si no hay
            Attractors = new List<Attractor>();
        }
        //se mete este atractor a la lista estatica
        Attractors.Add(this);
    }

    private void OnDisable() 
    {
        //si se quita el objeto attractor, se elimina de la lista
        Attractors.Remove(this);
    }

    private void FixedUpdate() 
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach (Attractor attractor in Attractors)
        {
            //si el attractor a atraer no es el mismo, se se atrae
            if (attractor != this)
            {
                Attract(attractor);
            }
        }
    }

    void Attract(Attractor objToAttract)
    {
        //se coge el rb
        Rigidbody rbToAttract = objToAttract.rb;

        //se calcula la direccion restando las posiciones
        Vector3 direction = rb.position - rbToAttract.position;
        //la distancia entre ellos es el tamaño del vector, esto ahorra hacer un pitagoras
        float distance = direction.magnitude;

        //si estan en el mismo lugar, se pasa de ello
        if (distance == 0)
        {
            return;
        }

        //se calcula la fuerza con la Ley de gravitacion universal: F = G((m1 * m2)/r^2)
        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        //se multiplica la fuerza a la direccion (normalizada)
        Vector3 force = direction.normalized * forceMagnitude;
        
        //se llama a la fuerza
        rbToAttract.AddForce(force);
    }
}
