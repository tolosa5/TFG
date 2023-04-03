using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTps : MonoBehaviour
{
    public int blackHoleId;

    private void OnEnable() 
    {
        EventManager.OnBlackHoleTriggerEnter += TpToWhiteHole;
    }

    private void OnDisable() 
    {
        EventManager.OnBlackHoleTriggerEnter -= TpToWhiteHole;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("BlackHole"))
        {
            EventManager.BlackHoleTriggerEnter(blackHoleId);
        }
    }

    public void TpToWhiteHole(int id)
    {
        if (id == blackHoleId)
        {
            Debug.Log("a brasil mirrey");
            
        }
    }
}
