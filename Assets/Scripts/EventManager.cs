using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    #region BlackHoles
    
    public static event Action<int> OnBlackHoleTriggerEnter;
    public static void BlackHoleTriggerEnter(int id)
    {
        OnBlackHoleTriggerEnter?.Invoke(id);
    }
    #endregion
}
