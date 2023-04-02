using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteHole : MonoBehaviour
{
    public int triggerId;
    public static List<WhiteHole> WhiteHoles;

    private void OnEnable() 
    {
        EventManager.OnBlackHoleTriggerEnter += TpToWhiteHole;

        if (WhiteHoles == null)
        {
            WhiteHoles = new List<WhiteHole>();
        }

        WhiteHoles.Add(this);
    }

    private void OnDisable() 
    {
        EventManager.OnBlackHoleTriggerEnter -= TpToWhiteHole;

        WhiteHoles.Remove(this); 
    }

    public void TpToWhiteHole(int id)
    {
        if (id == triggerId)
        {
            Debug.Log("a brasil mirrey");
            
        }
    }
}
