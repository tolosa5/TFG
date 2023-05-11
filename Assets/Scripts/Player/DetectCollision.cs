using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public float bottomOffset;
    public float frontOffset;
    public float collisionRadius;
    public LayerMask GroundLayer;

    public bool CheckGround(Vector3 direction)
    {
        Vector3 pos = transform.position + (direction * bottomOffset);
        Collider[] colls = Physics.OverlapSphere(pos, collisionRadius, GroundLayer);

        if (colls.Length > 0)
        {
            //estas en suelo
            return true;
        }
        //no estas en suelo
        return false;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Vector3 Pos = transform.position + (-transform.up * bottomOffset);
        Gizmos.DrawSphere(Pos, collisionRadius);
    }
}
