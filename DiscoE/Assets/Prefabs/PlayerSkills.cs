using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills
{
    public event EventHandler OnSkillPointsChanged; 
    public event EventHandler<OnSkillUnlockedEventArgs> OnSkillUnlocked;

    public class OnSkillUnlockedEventArgs : EventArgs
    {
        public SkillType skillType;
    }
    public enum SkillType
    {
        None,
        Speed,
        Speed2,
        Brave
    }

    private List<SkillType> unlockedSkillTypeList;
    private int skillPoints;

    public PlayerSkills()
    {
        unlockedSkillTypeList = new List<SkillType>();
    }

    public void AddSkillPoint()
    {
        skillPoints++;
        OnSkillPointsChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetSkillPoints()
    {
        return skillPoints;
    }

    private void UnlockSkill(SkillType skillType)
    {
        if (!isSkillUnlocked(skillType))
        {
            unlockedSkillTypeList.Add(skillType);
            OnSkillUnlocked?.Invoke(this, new OnSkillUnlockedEventArgs { skillType = skillType });
        }
    }

    public bool isSkillUnlocked(SkillType skillType)
    {
        return unlockedSkillTypeList.Contains(skillType);
    }

    public bool CanUnlock(SkillType skillType)
    {
        SkillType skillRequirement = GetSkillRequierement(skillType);

        if(skillRequirement != SkillType.None)
        {
            if (isSkillUnlocked(skillRequirement))
            {
                return true;
            }
            else
                return false;
        }
        else
        {
            return true;
        }
    }

    public SkillType GetSkillRequierement(SkillType skillType)
    {
        switch (skillType)
        {
            case SkillType.Speed2 : return SkillType.Speed;
        }
        return SkillType.None;
    }

    public bool TryUnlockSkill(SkillType skillType)
    {
        if (CanUnlock(skillType))
        {
            if (skillPoints > 0) {
                skillPoints--;
                OnSkillPointsChanged?.Invoke(this, EventArgs.Empty);
                UnlockSkill(skillType);
                return true;
               }
            else
            {
                ToolTip_Warning.ShowTooltipWarning_Static("Coudn't buy");
                return false;
            }
        }
        else
        {
            ToolTip_Warning.ShowTooltipWarning_Static("Coudn't buy");
            return false;
        }
    }
}

