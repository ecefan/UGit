using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem 
{

    public event EventHandler OnLevelChanged; //Событие когда изменяется уровень
    private int level;
    private int expereince;
    

    private static readonly int[] experiencePerLevel = new[] { 100, 120, 140, 160, 180, 200, 220, 250, 300, 400 }; 
    public LevelSystem()
    {
        level = 0;
        expereince = 0;
        
    }

    public void AddExperience(int amount)
    {
        if (!IsMaxLevel())
        {
            expereince += amount;
            while (!IsMaxLevel() && expereince >= GetExperienceToNextLevel(level))
            {
                level++;
                expereince -= GetExperienceToNextLevel(level);
                if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
            }
        }
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public int GetExperienceToNextLevel(int level)
    {
        if (level < experiencePerLevel.Length)
        {
            return experiencePerLevel[level];
        }
        else
        {

            Debug.LogError("Level invalid:" + level);
            return 100;
        }
    }


    public bool IsMaxLevel()
    {
        return IsMaxLevel(level);
    }
    public bool IsMaxLevel(int level)
    {
        return level == experiencePerLevel.Length - 1;
    }
}
