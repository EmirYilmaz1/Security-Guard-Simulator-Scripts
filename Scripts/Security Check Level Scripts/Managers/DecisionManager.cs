using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionManager : MonoBehaviour
{
    public event Action OnButtonPressed;
    
    void Start()
    {
        FindObjectOfType<IDText>().OnEnteredIDTrue += ActivateButton;
        SubsucribeToChilds();
    }

    private void SubsucribeToChilds()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<DecisionButton>().OnDecisionMade += ButtonPressed;
        }
    }

    private void ActivateButton()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        } 
    }

    private void ButtonPressed()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        } 
        OnButtonPressed?.Invoke();
    }
}
