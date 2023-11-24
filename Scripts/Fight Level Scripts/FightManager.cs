using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    [SerializeField] private GameObject PowerBar;

    public Health theifHealth;
    


    private PowerArrow powerArrow;
    [SerializeField] private  AttackHandler playerAttackHandler;
    [SerializeField] private AttackHandler thiefAttackHandler;
    

    void Start()
    {

        powerArrow = FindObjectOfType<PowerArrow>();


        powerArrow.OnClick += ClosePowerBar;

        playerAttackHandler.OnAttackFinished += ActivateThiefTurn;
        thiefAttackHandler.OnAttackFinished += ActivatePlayerTurn;
    }

    public void ActivatePlayerTurn()
    {
        PowerBar.SetActive(true);
        powerArrow.enabled = true;
    }

    public void ClosePowerBar()
    {
        PowerBar.SetActive(false);
    }

    public void ActivateThiefTurn()
    {
        thiefAttackHandler.PlayFistAnimation();
    }
}
