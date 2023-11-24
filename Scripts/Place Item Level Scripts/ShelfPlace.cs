using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfPlace : MonoBehaviour
{
    public event Action OnShelfChange;

    [SerializeField] private bool isEmpty = true;
    public bool IsEmpty{get{return isEmpty;}set{isEmpty = value;  OnShelfChange?.Invoke();}}    
}
