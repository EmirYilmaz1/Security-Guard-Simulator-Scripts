using TMPro;
using UnityEngine;

public class PeopleInfoText : MonoBehaviour 
{
    IDText iDText;

    private IDManager iDManager;
    private DecisionManager decisionManager;

    
    private void Awake() 
    {

        iDManager = FindObjectOfType<IDManager>();
        iDText = FindObjectOfType<IDText>();
        decisionManager = FindObjectOfType<DecisionManager>();
        
        iDText.OnEnteredIDTrue += SetInfoText;
        decisionManager.OnButtonPressed += ClearText;
    }   

    private void SetInfoText()
    {
        transform.Find("ID_Number_Text").GetComponent<TextMeshPro>().text = $"ID number: {iDManager.CurrentID.peopleId}";
        transform.Find("People_Name_Text").GetComponent<TextMeshPro>().text = $"Name: {iDManager.CurrentID.peopleName}";
        transform.Find("People_Age_Text").GetComponent<TextMeshPro>().text = $"Age: {iDManager.CurrentID.peopleAge}";
        transform.Find("Work_Text").GetComponent<TextMeshPro>().text = $"Job: {iDManager.CurrentID.peopleWork}";
    }

    private void ClearText()
    {
        foreach(Transform texts in transform)
        {
            texts.GetComponent<TextMeshPro>().text = "";
        }
    }


}