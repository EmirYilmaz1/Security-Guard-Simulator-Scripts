using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionButton : MonoBehaviour
{

  public event Action OnDecisionMade;
  public event Action OnFalseDecisionMade;

  private int trueDecisionCount;

  [SerializeField] private bool  canPassButton;

   public void PressedButton()
   {
        if(canPassButton== !FindObjectOfType<IDManager>().doesPeopleHaveFakeID)
        {
        }
        else
        {
          OnFalseDecisionMade?.Invoke();
        }
        OnDecisionMade?.Invoke();
   }
}
