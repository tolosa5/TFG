using UnityEngine;

public class GravityAreaPoint : GravityArea
{
    public override Vector3 GetGravityDirection(GravityBody gravityBody)
    {
        return -transform.up;
    }
}
