using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    [SerializeField] float health, maxHealth = 3f;


    [SerializeField] FloatingHealthBar healthBar;


    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }


    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }


    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            health = 0;
            OnPlayerDeath?.Invoke();
        }
    }
}
