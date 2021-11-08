using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class LevelWindow : MonoBehaviour
{
    public Text levelText;
    public Button button;
    
    private LevelSystem levelSystem;
    private void Awake()
    {
        //levelText = transform.Find("levelText").GetComponent<Text>();
        
    }

    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = "Level " + (levelNumber + 1);
    }

    public void SetLevelSystem(LevelSystem levelSystem) 
    {
        this.levelSystem = levelSystem;
        SetLevelNumber(levelSystem.GetLevelNumber());
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnLevelChanged(object sender, EventArgs e) 
    {
        SetLevelNumber(levelSystem.GetLevelNumber());               
    }

    public void Add() //Добавить экспу (кнокпка тестовая)   
    {
        levelSystem.AddExperience(80); 
    }
}
