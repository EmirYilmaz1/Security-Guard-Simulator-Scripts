using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IDText : MonoBehaviour
{
    public Action OnEnteredIDTrue;

    private TextMeshPro idText;
    private SecurityLevelPlayerRaycast playerRaycast;
    private IDManager iDManager;
    private DecisionManager decisionManager;

    private int idWrotedInComputer;
    void Start()
    {
        idText = GetComponent<TextMeshPro>();
        iDManager = FindObjectOfType<IDManager>();

        playerRaycast = FindObjectOfType<SecurityLevelPlayerRaycast>();
        playerRaycast.OnKeyClicked += AddNumber;

        decisionManager = FindObjectOfType<DecisionManager>();
        decisionManager.OnButtonPressed += EnableText;
    }

    public void AddNumber(int number)
    {
        if(idText.text.Length<5)
        {

            idText.text = idText.text+number;
            if(int.TryParse(idText.text,out  idWrotedInComputer))
            {
                if(idWrotedInComputer==iDManager.CurrentID.peopleId)
                {
                   OnEnteredIDTrue?.Invoke();
                   ClearIDText();
                   idText.enabled = false;
                }
            }
        }
    }

    public void ClearIDText()
    {
        idText.text = "";
    }

    private void EnableText()
    {
        idText.enabled = true;
    }
}
