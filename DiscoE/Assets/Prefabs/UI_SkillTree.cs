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
    private void Awake()
    {
        

        transform.Find("SpeedBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Speed);
        };
        transform.Find("Speed2Btn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            playerSkills.TryUnlockSkill(PlayerSkills.SkillType.Speed2);
        };
        transform.Find("BraveBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {

        };
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
