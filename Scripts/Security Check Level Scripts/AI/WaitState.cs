using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : State
{

    private PeopleInLineManager peopleInLineManager;
    private GetInFrontState getInFrontState;
    private WalkState walkState;
    private void Awake() 
    {
        peopleInLineManager = GetComponent<PeopleInLineManager>();
        getInFrontState = GetComponent<GetInFrontState>();
        walkState = GetComponent<WalkState>();
    }

    public override State Tick()
    {
        if(peopleInLineManager.isLineMoved)
        {
            peopleInLineManager.animatorManager.PlayTargetAnim("Walk");
            return walkState;
        }
        
        if(peopleInLineManager.inFrontOfTheLine)
        {
            peopleInLineManager.Fronts();
            return getInFrontState;
        }


        return this;
    }

}