using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour 
{
    
    public Player Player;
    public UI_SkillTree uI_SkillTree;
    public LevelWindow levelwindow;

    private void Awake() //������ ����� ������� ������ ��� ������ � ����������
    {
        LevelSystem levelSystem = new LevelSystem();
        Player.SetLevelSystem(levelSystem);
        levelwindow.SetLevelSystem(levelSystem);
    }

    private void Start() //������ ����� ���������
    {
        uI_SkillTree.SetPlayerSkills(Player.GetPlayerSkills());
    }
}
