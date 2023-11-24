using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    [SerializeField] [Range(1,6)] private int keyNumber; 
    
    public int KeyClicked()
    {
        return keyNumber;
    }

}
