using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float damage = 10f;
    public float fireRate = 0.5f;
    
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void IncreaseHealth(int amount)
    {
        maxHealth += amount;
        currentHealth = maxHealth;

        PlayerHealth ph = GetComponent<PlayerHealth>();
        if(ph != null )
        {
            ph.SetNewMaxHealth(maxHealth);
        }
    }



    public void IncreaseDamage(int amount)
    {
        damage += amount;
    }

    public void IncreaseFireRate(float multiplier)
    {
        fireRate *= (1f - multiplier);
        fireRate = Mathf.Max(0.05f, fireRate);
    }



}
