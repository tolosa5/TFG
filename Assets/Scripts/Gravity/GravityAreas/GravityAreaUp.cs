using UnityEngine;

public class GravityAreaUp : GravityArea
{
    public override Vector3 GetGravityDirection(GravityBody gravityBody)
    {
        return -transform.up;
    }
}
