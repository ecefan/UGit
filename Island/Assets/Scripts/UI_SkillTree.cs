using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;
using System;

public class UI_SkillTree : MonoBehaviour
{
    private PlayerSkills playerSkills;
    public Text Points;

    public Button_UI brave;
    public Button_UI brave2;
    public Button_UI health;
    public Button_UI health2;
    public Button_UI speed;
    public Button_UI speed2;

    private void Awake()
    {

        brave.ClickFunc = () => { playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Brave); };
        brave2.ClickFunc = () => { playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Brave2); };
        health.ClickFunc = () => { playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Health); };
        health2.ClickFunc = () => { playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Health2); };
        speed.ClickFunc = () => { playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Speed); };
        speed.ClickFunc = () => { playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Speed2); };
    }

    public void SetPlayerSkills(PlayerSkills playerSkills)
    {
        this.playerSkills = playerSkills;
        playerSkills.OnSkillPointsChanged += PlayerSkill_OnSkillPointChanged;
    }

    private void PlayerSkill_OnSkillPointChanged(object sender, System.EventArgs e)
    {
        UpdateSkillPoints();
    }

    private void UpdateSkillPoints()
    {
        Points.text = "POINTS " + (playerSkills.GetSkillPoints().ToString());
    }
}
