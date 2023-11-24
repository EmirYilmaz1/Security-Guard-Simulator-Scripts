using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteIDInfo : MonoBehaviour
{
   [SerializeField] private DecisionButton[] decisionButtons;
   private void Start() 
   {
      SubsucribeTheDecisionButtons();
   }
    private void SubsucribeTheDecisionButtons()
    {
      foreach (DecisionButton button in decisionButtons)
      {
         button.OnDecisionMade += ClearText;
      }
    }

    public void WriteText(People iDManager)
   {
      transform.Find("ID_Number_Text").GetComponent<TextMeshPro>().text = $"Number: {iDManager.peopleId}";
      transform.Find("People_Name_Text").GetComponent<TextMeshPro>().text = $"Name: {iDManager.peopleName}";
      transform.Find("People_Age_Text").GetComponent<TextMeshPro>().text = $"Age: {iDManager.peopleAge}";
      transform.Find("Work_Text").GetComponent<TextMeshPro>().text = $"Job: {iDManager.peopleWork}";
   }

   private void ClearText()
   {
      transform.Find("ID_Number_Text").GetComponent<TextMeshPro>().text = $"Number:";
      transform.Find("People_Name_Text").GetComponent<TextMeshPro>().text = $"Name: ";
      transform.Find("People_Age_Text").GetComponent<TextMeshPro>().text = $"Age: ";
      transform.Find("Work_Text").GetComponent<TextMeshPro>().text = $"Job:";
   }
}
