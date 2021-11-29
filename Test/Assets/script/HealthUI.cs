using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private PlayerHealth health;
    public Slider healthBar;

    void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = health.maxHealth;
        healthBar.value = health.currentHealth;
    
    }

}
