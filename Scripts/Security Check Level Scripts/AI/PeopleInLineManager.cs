using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleInLineManager : MonoBehaviour
{
    public AnimatorManager animatorManager;

    [Header("Line Info's")]
    public bool isDecisionMake;
    public bool inFrontOfTheLine;
    public bool isLineMoved;
    public Transform currentLinePosition;
    public Transform finishPosition;

    [Header("ID Info's")]
    public People peopleInfo;
    public bool doesHaveFakeId;
    public People fakePeopleInfo; 
    
    private void Awake() {
        animatorManager = GetComponent<AnimatorManager>();
    }
    public void Fronts()
    {
        FindObjectOfType<IDManager>().SetID(this);
    }
}
