using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    public event Action OnAttackFinished;

    private  Animator animator;
    private PowerArrow powerArrow;
    [SerializeField] private Health enemyHealth;


    private void Awake() {
        powerArrow = FindObjectOfType<PowerArrow>();
        animator = GetComponent<Animator>();
    }

    public void PlayFistAnimation()
    {
        animator.CrossFade("Fist",.1f);
    }

    public void DamageEnemy()
    {
        if (powerArrow.ArrowDistance > -1.2f)
        {
            enemyHealth.CurrentHealth -= 1;
        }
        else if (-1.2f > powerArrow.ArrowDistance && powerArrow.ArrowDistance > -2.6f)
        {
            enemyHealth.CurrentHealth -= 4;
        }
        else
        {
            enemyHealth.CurrentHealth -= 10;
        }

        OnAttackFinished?.Invoke();

    }

    public void DamagePlayer()
    {
        int damage = UnityEngine.Random.RandomRange(1,9);
        enemyHealth.CurrentHealth -= damage;
        OnAttackFinished?.Invoke();
    }
}
