using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrityColliderHandler : MonoBehaviour
{
    public event Action OnCelebrityArrivedTaxi;
    public event Action OnFansTouchedCelebrity;

    private void OnTriggerEnter(Collider other) 
    {    
        if(other.gameObject.CompareTag("Fans"))
        {
            OnFansTouchedCelebrity?.Invoke();
        }
        
        if(other.gameObject.CompareTag("Taxi"))
        {
            OnCelebrityArrivedTaxi?.Invoke();
        }
    }
}
