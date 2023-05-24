using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    [SerializeField] Transform pivotTransform;
    [SerializeField] float rotationSpeed;

    void Update()
    {
        transform.RotateAround(pivotTransform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
