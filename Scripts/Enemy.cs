using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
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
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent<Health>(out Health healthComponent))
        {
            healthComponent.TakeDamage(1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent<Health>(out Health healthComponent))
        {
            healthComponent.TakeDamage(1);
        }
    }
}
