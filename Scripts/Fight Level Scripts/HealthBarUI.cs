using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Health health;
    private Slider healthBar;

    void Start()
    {
        healthBar = GetComponent<Slider>();
        health.OnHealthChange += SetBar;
    }

    private void SetBar()
    {
        healthBar.value = health.CurrentHealth;
    }

}
