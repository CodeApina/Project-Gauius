using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Character_Level_Handler character_level = new Character_Level_Handler(1,0,100);
    public Unit_Health character_health = new Unit_Health(100f,100f,2.5f);
    public Unit_Damage character_damage = new Unit_Damage(5,10,2f,10);
    public Unit_Mana character_mana = new Unit_Mana(100f, 100f, 2.5f);
    public bool character_alive = true;

    private void OnEnable()
    {
        Character_Level_Handler.OnLevelChange += Handle_Character_Level_Change;
        Character_Behaviour.On_Character_Death += Handle_Character_Death;
    }
    private void OnDisable()
    {
        Character_Level_Handler.OnLevelChange -= Handle_Character_Level_Change;
        Character_Behaviour.On_Character_Death -= Handle_Character_Death;
    }
    void Handle_Character_Death(Character_Behaviour character)
    {
        character_alive = false;
        Debug.Log("Player died");
    }
    void Handle_Character_Level_Change(Character_Level_Handler character)
    {
        Debug.Log("Level: " + character_level.level);
        character_level.Level_Up();
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        character_alive = true;
    }
}
