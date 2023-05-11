using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    public static PlayerAnims instance;

    Animator playerAnim;

    private void Awake() 
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

        playerAnim = GetComponent<Animator>();
    }
    
    private void Update() 
    {
        
    }

    void HandleAnimations()
    {
        
    }

}
