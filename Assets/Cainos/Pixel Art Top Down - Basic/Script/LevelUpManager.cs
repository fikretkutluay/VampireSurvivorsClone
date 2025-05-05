using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour
{
    public GameObject levelUpPanel;
    public PlayerStats playerStats;


    public void OpenPanel()
    {
        Debug.Log("Panel Açýlýyor");
        levelUpPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePanel()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpgradeHealth()
    {
        playerStats.IncreaseHealth(20);
        ClosePanel();
    }

    public void UpgradeDamage()
    {
        playerStats.IncreaseDamage(5);
        ClosePanel();
    }

    public void UpgradeFireRate()
    {
        playerStats.IncreaseFireRate(0.2f);
        ClosePanel();
    }
}
