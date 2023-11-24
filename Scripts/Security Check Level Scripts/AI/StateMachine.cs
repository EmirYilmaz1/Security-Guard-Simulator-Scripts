using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State currentState;
    void Update()
    {
        HandleNewState();
    }
    
    public void HandleNewState()
    {
        State newState = currentState?.Tick();

        if(newState != null)
        {
            currentState = newState;
        }
        else
        {
            return;
        }
    }
}
