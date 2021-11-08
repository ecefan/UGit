using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public Tilemap map;
    MouseInput mouseInput;
    public float speed = 4f;
    private Vector3 destination;
    private LevelSystem levelSystem;
    private PlayerSkills playerSkills;



    private void Awake()
    {
        levelSystem = new LevelSystem();
        mouseInput = new MouseInput();
        playerSkills = new PlayerSkills();
        playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
    }

    private void OnEnable()
    {
        mouseInput.Enable();
    }

    private void OnDisable()
    {
        mouseInput.Disable();
    }

    private void Start()
    {
        destination = transform.position;
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
    }

    private void MouseClick()
    {
        Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        if (map.HasTile(gridPosition))
        {
            destination = mousePosition;
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
    }

    private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEventArgs e)
    {
        switch (e.skillType)
        {
            case PlayerSkills.SkillType.Speed:
                SetSpeed(10f);
                break;
            case PlayerSkills.SkillType.Speed2:
                SetSpeed(20f);
                break;
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

    private void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
