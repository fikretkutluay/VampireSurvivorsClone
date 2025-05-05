using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPManager : MonoBehaviour
{   
    public int currentXP = 0;
    public int currentLevel = 1;
    public int xpToNextLevel = 50;
    
    public LevelUpManager levelUpManager;
    

    public void AddXP(int amount)
    {
        currentXP += amount;
        Debug.Log("XP eklendi: " + currentXP);
        while (currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }
    private void LevelUp()
    {
        currentLevel++;
        currentXP -= xpToNextLevel;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.3f);
        Debug.Log("LEVEL UP");

        if (levelUpManager == null)
        {
            Debug.LogError("LevelUpManager atanmadý!");
            return;
        }
        levelUpManager.OpenPanel();
        
    }
}