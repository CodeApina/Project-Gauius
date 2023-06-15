using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Player_Level player_level = new Player_Level(1,0,100);
    public Unit_Health player_health = new Unit_Health(100f, 100f,2.5f);
    public Unit_Damage player_damage = new Unit_Damage(10, 2f,10);
    public bool player_alive;

    private void OnEnable()
    {
        Player_Level.OnLevelChange += Handle_Player_Level_Change;
        Player_Behaviour.On_Player_Death += Handle_Player_Death;
    }
    private void OnDisable()
    {
        Player_Level.OnLevelChange -= Handle_Player_Level_Change;
        Player_Behaviour.On_Player_Death -= Handle_Player_Death;
    }
    void Handle_Player_Death(Player_Behaviour player)
    {
        player_alive = false;
        Debug.Log("Player died");
    }
    void Handle_Player_Level_Change(Player_Level player)
    {
        Debug.Log("Level: " + player_level.level);
        player_damage.damage = player_damage.damage * player_level.level;
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
    }
}
