using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action OnHealthChange;
    public event Action OnDefeat;



    [SerializeField] private bool isPlayer;

    private int currentHealth = 20;
    public int CurrentHealth
    {
        get{return currentHealth;}
        set
        {
            currentHealth = value; 
            
            OnHealthChange?.Invoke(); 
            
            if(currentHealth<=0)
            {
                OnDefeat?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
