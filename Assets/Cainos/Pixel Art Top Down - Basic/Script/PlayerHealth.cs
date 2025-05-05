using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthBarFill;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private float flashDuration = 0.1f;

    private Color originalColor;
    public PlayerStats playerStats;

    private void Start()
    {
        originalColor = spriteRenderer.color;

        playerStats.currentHealth = playerStats.maxHealth;
        UpdateHealthBar();
       
    }

    public void TakeDamage(int amount)
    {   
        playerStats.currentHealth -= amount;
        if (playerStats.currentHealth < 0)
            playerStats.currentHealth = 0;
        UpdateHealthBar();
        StartCoroutine(FlashSprite());

        if (playerStats.currentHealth <= 0)
        {
            Die();
        }
      
    }
    public void Heal(int amount)
    {
        playerStats.currentHealth += amount;
        if(playerStats.currentHealth > playerStats.maxHealth)
            playerStats.currentHealth =playerStats.maxHealth;
        UpdateHealthBar() ;
    }

    private IEnumerator FlashSprite()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
    public void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)playerStats.currentHealth / playerStats.maxHealth;
        }
    }

    public void SetNewMaxHealth(int newMax)
    {
        playerStats.maxHealth = newMax;
        playerStats.currentHealth = newMax;
        UpdateHealthBar();
    }
    
    private void Die()
    {
        Debug.Log("Player died! ");
        Destroy(gameObject);
    }

}
