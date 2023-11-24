using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnterIDUI : MonoBehaviour
{
    private TextMeshPro enterIdText;
    private SecurityLevelPlayerRaycast playerRaycast;
    private DecisionManager decisionManager;
    private void Awake() 
    {
        enterIdText = GetComponent<TextMeshPro>();

        playerRaycast= FindObjectOfType<SecurityLevelPlayerRaycast>();
        playerRaycast.OnKeyClicked += DisableEnterIDText;

        decisionManager = FindObjectOfType<DecisionManager>();
        decisionManager.OnButtonPressed += EnableEnterIDText;
    }

    private void DisableEnterIDText(int a)
    {
        enterIdText.enabled = false;
        playerRaycast.OnKeyClicked -= DisableEnterIDText;
    }

    private void EnableEnterIDText() 
    {
        enterIdText.enabled = true;
        playerRaycast.OnKeyClicked += DisableEnterIDText;

    }
}
