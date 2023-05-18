using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    [SerializeField] Transform platformTransform;
    [SerializeField] GameObject platformGO;
    [SerializeField] GameObject flame1;
    [SerializeField] GameObject flame2;
    bool flying;

    private void Start() 
    {
        platformGO.SetActive(false);
        platformTransform.GetComponent<Animator>();
    }

    private void Update() 
    {
        if (Input.GetKey(KeyCode.F))
        {
            JetPackFly();
        }    
        if (Input.GetKeyUp(KeyCode.F))
        {
            StopJetPack();
        }   
    }

    void JetPackFly()
    {
        flying = true;
        flame1.SetActive(true);
        flame2.SetActive(true);
        platformGO.transform.SetParent(platformTransform);

        platformGO.SetActive(true);
    }

    void StopJetPack()
    {
        flying = false;
        flame1.SetActive(false);
        flame2.SetActive(false);

        platformGO.SetActive(false);
    }
}
