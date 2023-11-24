using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public event Action OnLevelFinished; 

    [SerializeField] private List<PeopleInLineManager> peopleWaitingInTheLine;

    [Header("Line Transforms")]
    [SerializeField] private List<Transform> line;
    [SerializeField] private Transform finishLine;

    private void Awake() 
    {

        SpawnPeople();
        peopleWaitingInTheLine[0].GetComponent<PeopleInLineManager>().inFrontOfTheLine = true;
        FindObjectOfType<DecisionManager>().OnButtonPressed += SetLine;
    }

    private void SpawnPeople()
    {
        PeoplePool peoplePool = FindObjectOfType<PeoplePool>();

        int currentIndex;
        float lastIndex = Mathf.Infinity;
        for(int i = 0; i<3; i++)
        {
            do
            {
             currentIndex = UnityEngine.Random.RandomRange(0, peoplePool.peoplePoolManager.Count); 
            } while (currentIndex==lastIndex);

            GameObject people = Instantiate(peoplePool.peoplePoolManager[currentIndex],line[i].position, Quaternion.identity);
            people.transform.rotation = Quaternion.Euler(0,180,0);
            PeopleInLineManager peopleInLineManager = people.GetComponent<PeopleInLineManager>();
            peopleInLineManager.finishPosition = finishLine;
            peopleWaitingInTheLine[i] = peopleInLineManager;
            lastIndex = currentIndex;
        }
    }

    private void SetLine()
    {
        if(peopleWaitingInTheLine.Count>1)
        {
            peopleWaitingInTheLine[0].isDecisionMake = true;
            peopleWaitingInTheLine.Remove(peopleWaitingInTheLine[0]);
            peopleWaitingInTheLine[0].inFrontOfTheLine = true;
            
            for(int i = 0; i<peopleWaitingInTheLine.Count; i++)
            {
                peopleWaitingInTheLine[i].currentLinePosition = line[i];
                peopleWaitingInTheLine[i].isLineMoved = true;
            }
        }
        else
        {
            OnLevelFinished?.Invoke();
        }
    }
}
