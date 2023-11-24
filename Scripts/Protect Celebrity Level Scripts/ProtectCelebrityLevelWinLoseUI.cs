using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectCelebrityLevelWinLoseUI : MonoBehaviour
{
    CelebrityColliderHandler celebrityColliderHandler;

    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Canvas loseCanvas;

    void Start()
    {
        celebrityColliderHandler = FindObjectOfType<CelebrityColliderHandler>();
        celebrityColliderHandler.OnCelebrityArrivedTaxi += OpenWinCanvas;
        celebrityColliderHandler.OnFansTouchedCelebrity += OpenLoseCanvas;
    }

    private void OpenWinCanvas()
    {
        Time.timeScale = 0;
        winCanvas.enabled = true;
    }

    private void OpenLoseCanvas()
    {
        Time.timeScale = 0;
        loseCanvas.enabled = true;
    }
}
