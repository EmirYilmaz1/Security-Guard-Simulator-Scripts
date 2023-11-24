using UnityEngine;

public class GetInFrontState : State
{
    PeopleInLineManager peopleInLineManager;
    WalkState walkState;
    private void Awake() 
    {
        walkState = GetComponent<WalkState>();
        peopleInLineManager = GetComponent<PeopleInLineManager>();    
    }

    public override State Tick()
    {
        if(peopleInLineManager.isDecisionMake)
        {
            peopleInLineManager.animatorManager.PlayTargetAnim("Walk");
           return walkState;
        }
        return this;
    }
}