using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider; 
    public float startingHealth = 100f; 
    public float currentHealth;
    [SerializeField] private AudioClip deathSound;  
    [SerializeField] private AudioSource audioSource;

    private void OnEnable()
    {
        EventManager.OnZombieDamage += TakeDamage;
    }

    private void OnDisable()
    {
        EventManager.OnZombieDamage -= TakeDamage;
    }

    void Start()
    {
        currentHealth = startingHealth;
        UpdateHealthSlider();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthSlider();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        audioSource.clip = deathSound;
        audioSource.Play();
        EventManager.PlayerDeath();
    }
    void UpdateHealthSlider()
    {
        healthSlider.value = currentHealth;
    }
}
