using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Unit_Health character_health = new Unit_Health(100f,100f,2.5f);
    public Unit_Damage character_damage = new Unit_Damage(50,100,2f,10);
    [SerializeField] public Unit_Mana character_mana = new Unit_Mana(100f, 100f, 2.5f);
    public bool character_alive = true;
    public GameObject character;

    private void OnEnable()
    {
        Character_Behaviour.On_Character_Death += Handle_Character_Death;
    }
    private void OnDisable()
    {
        Character_Behaviour.On_Character_Death -= Handle_Character_Death;
    }
    void Handle_Character_Death(Character_Behaviour character)
    {
        character_alive = false;
        Debug.Log("Player died");
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
        DontDestroyOnLoad(this);
        character = GameObject.FindGameObjectWithTag("Player");
    }
}
