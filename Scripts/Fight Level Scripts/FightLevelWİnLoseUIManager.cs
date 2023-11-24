using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FightLevelWİnLoseUIManager : MonoBehaviour
{
    [Header("Win & Lose Canvas")]
    [SerializeField] private Canvas failedCanvas;
    [SerializeField] private Canvas winCanvas;


    [Header("Healths")]
    [SerializeField] private Health playerHealth;
    [SerializeField] private Health enemyHealth;
    
    void Start()
    {
        playerHealth.OnDefeat += OpenLoseCanvas;
        enemyHealth.OnDefeat += OpenWinCanvas;
    }

    private void OpenLoseCanvas()
    {
        Time.timeScale = 0;
        failedCanvas.enabled = true;
    }

    private void OpenWinCanvas()
    {
        Time.timeScale = 0;
        winCanvas.enabled = true;
    }


}
