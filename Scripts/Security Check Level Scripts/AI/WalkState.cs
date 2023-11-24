using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkState : State
{
    private PeopleInLineManager peopleInLineManager;
    private NavMeshAgent navMeshAgent;
    private WaitState waitState;

    private void Awake() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        peopleInLineManager = GetComponent<PeopleInLineManager>();
        waitState = GetComponent<WaitState>();    
    }

    public override State Tick()
    {
        if(peopleInLineManager.isDecisionMake)
        {
            navMeshAgent.SetDestination(peopleInLineManager.finishPosition.position);
            return this;
        }   

        if(peopleInLineManager.isLineMoved)
        {
            navMeshAgent.SetDestination(peopleInLineManager.currentLinePosition.position);
            if(0.02f>Vector3.Distance(transform.position,peopleInLineManager.currentLinePosition.position))
            {
                peopleInLineManager.isLineMoved = false;
                peopleInLineManager.animatorManager.PlayTargetAnim("Idle");
                return waitState;
            }
            return this;
        }

       return this;
    }
}
