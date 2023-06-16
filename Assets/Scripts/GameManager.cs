using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Character_Level_Handler player_level = new Character_Level_Handler(1,0,100);
    public Unit_Health player_health = new Unit_Health(100f,100f,2.5f);
    public Unit_Damage player_damage = new Unit_Damage(5,10,2f,10);
    public bool player_alive;
    public UI_Manager ui_manager;

    private void OnEnable()
    {
        Character_Level_Handler.OnLevelChange += Handle_Player_Level_Change;
        Character_Behaviour.On_Player_Death += Handle_Player_Death;
    }
    private void OnDisable()
    {
        Character_Level_Handler.OnLevelChange -= Handle_Player_Level_Change;
        Character_Behaviour.On_Player_Death -= Handle_Player_Death;
    }
    void Handle_Player_Death(Character_Behaviour player)
    {
        player_alive = false;
        Debug.Log("Player died");
    }
    void Handle_Player_Level_Change(Character_Level_Handler player)
    {
        Debug.Log("Level: " + player_level.level);
        player_level.Level_Up();
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
        player_alive = true;
        ui_manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }
}
