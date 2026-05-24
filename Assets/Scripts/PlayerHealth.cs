using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    private int currentHealth;
    public event Action<int, int> OnHealthChanged;
    public int CurrentHealth => currentHealth;
    public bool IsDead => isDead;


    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Player Health Initialized: " + currentHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // TakeDamage Method
    public void TakeDamage(int damageAmount)
    {
        if (isDead) return;

        currentHealth -= damageAmount;
        if (currentHealth < 0) currentHealth = 0;
        OnHealthChanged?.Invoke(currentHealth,maxHealth);

        

        // Console log test for damage
        Debug.Log("Player took damage: " + damageAmount);
        Debug.Log("Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Death Trigger
    void Die()
    {
        isDead = true;
        Debug.Log("Player has died!");
        if (GameManager.Instance != null)
            GameManager.Instance.TriggerGameOver();
    }
}

