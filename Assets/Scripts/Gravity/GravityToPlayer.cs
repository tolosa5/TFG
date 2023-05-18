using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityToPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject[] planets;

    Vector3 movementY;
    float factorG = -9.81f;
    float jumpHeight = 0.8f;

    void Update()
    {
        LookForNearestPlanet();

        movementY.y += factorG * Time.deltaTime;

        //si esta en el suelo
        movementY.y = 0;

        //si salta
        movementY.y = Mathf.Sqrt(jumpHeight * -2f * factorG);
    }

    void LookForNearestPlanet()
    {
        float distance = Vector3.Distance(transform.position, planets[0].transform.position);
        int nearestPlanet = 0;
        
        for (int i = 0; i < planets.Length; i++)
        {
            float distanceAux = Vector3.Distance(transform.position, planets[i].transform.position);
            if(distanceAux < distance)
            {
                distance = distanceAux;
                nearestPlanet = i;
            }
        }

        movementY = planets[0].transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(transform.up, -movementY) * transform.rotation;
    }
}
