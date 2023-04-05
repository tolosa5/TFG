using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform cam;

    private void OnEnable() 
    {
        cam = Camera.main.transform;    
    }

    private void FixedUpdate() 
    {
        transform.LookAt(cam);
        transform.Rotate(new Vector3 (1, 0, 0), 90);
    }
}
