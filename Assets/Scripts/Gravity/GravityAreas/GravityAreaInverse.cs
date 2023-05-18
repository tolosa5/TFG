using UnityEngine;

public class GravityAreaInverse : GravityArea
{
    [SerializeField] Vector3 center;
    public override Vector3 GetGravityDirection(GravityBody gravityBody)
    {
        return (gravityBody.transform.position - center).normalized;
    }
}
