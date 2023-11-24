using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDManager : MonoBehaviour
{
   [SerializeField] private People currentID;
    public People CurrentID{get{return currentID;} set{value= currentID;}}

    public bool doesPeopleHaveFakeID;
    [SerializeField] private People fakeID;
    public People FakeID{get{return fakeID;} set{value= fakeID;}}


    public void SetID(PeopleInLineManager peopleInFront)
    {
        currentID = peopleInFront.peopleInfo;
        doesPeopleHaveFakeID = peopleInFront.doesHaveFakeId;
        fakeID =peopleInFront.fakePeopleInfo;
        

        if(fakeID!=null)
        {
            FindObjectOfType<WriteIDInfo>().WriteText(fakeID);
        }
        else
        {
            FindObjectOfType<WriteIDInfo>().WriteText(currentID);
            
        }
    }

}
