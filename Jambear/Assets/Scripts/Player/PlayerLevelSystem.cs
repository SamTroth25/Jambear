﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLevelSystem : MonoBehaviour
{
    public int currentLevel;
    public float currentEXP;

    public float[] toLevelUp;

    public Text levelUI;
    public Image levelUpBarUI;
      
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        levelUI.text = ("" + currentLevel);
    }
    void Update()
    {
        if (currentEXP >= toLevelUp[currentLevel])
        {
            currentEXP = 0;
            currentLevel++;
            levelUI.text = ("" + currentLevel);
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        }        
    }
    public void AddEXP(float exp)
    {
        currentEXP += exp;
        levelUpBarUI.fillAmount = currentEXP / toLevelUp[currentLevel];
    }
}
