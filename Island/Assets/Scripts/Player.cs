using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
     

    public LayerMask whatCanBeClicked;

    public NavMeshAgent myAgent;
    public InventoryObject inventory;
    private LevelSystem levelSystem;
    private PlayerSkills playerSkills;

    public int Health;
    public int MaxHealth = 3;

    public int Madness;
    public int MaxMadness = 3;
    
    private void Awake()
    {
        Madness = 3;
        Health = 3;
        levelSystem = new LevelSystem();
        playerSkills = new PlayerSkills();
        playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
      
    }

    private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEventArgs e)
    {
        switch (e.skillType)
        {
            case PlayerSkills.SkillType.Speed:
                SetSpeed(6f);
                break;
            case PlayerSkills.SkillType.Speed2:
                SetSpeed(8f);
                break;

            case PlayerSkills.SkillType.Health:
                HealthUp(4);
                break;
            case PlayerSkills.SkillType.Health2:
                HealthUp(5);
                break;
            case PlayerSkills.SkillType.Brave:
                MadUp(4);
                break;
            case PlayerSkills.SkillType.Brave2:
                MadUp(5);
                break;
           
        }
    }

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast (myRay, out hitInfo, 100, whatCanBeClicked))
            {
                myAgent.SetDestination(hitInfo.point);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            inventory.Load();
        }
        if(Health <= 0)
        {
            Die();
        }
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    public PlayerSkills GetPlayerSkills()
    {
        return playerSkills;
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        // Some effects
        playerSkills.AddSkillPoint();
    }

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void SetSpeed(float speed)
    {
        myAgent.speed = speed;
    }

    private void HealthUp(int health)
    {
        MaxHealth = health;
    }
    private void MadUp(int mad)
    {
        MaxMadness = mad;
    }

    private void Die()
    {
        this.gameObject.SetActive(false);
    }

    public int GetHealth()
    {
        return Health;
    }

    public int GetMadness()
    {
        return Madness;
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
