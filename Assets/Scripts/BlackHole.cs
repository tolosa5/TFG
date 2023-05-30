using System.Collections;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public int triggerId;

    [HideInInspector] 
    public GameObject obj;

    Rigidbody objRb;

    [SerializeField] GameObject whiteHole;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            obj = other.gameObject;
            Debug.Log("entrando");

            obj.transform.position = whiteHole.transform.position;
            Debug.Log("Tp al blanco");

            objRb = obj.GetComponent<Rigidbody>();
            objRb.velocity /= 5;

            StartCoroutine(DragWait());
            
        }
    }

    IEnumerator DragWait()
    {
        objRb.drag = 1;
        yield return new WaitForSeconds(0.5f);
        objRb.drag = 0;
    }
}
