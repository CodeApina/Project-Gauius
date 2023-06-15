using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : MonoBehaviour
{
    public static event Action<Player_Behaviour> On_Player_Death;
    void Start()
    {
        InvokeRepeating("Player_Regen",0.1f,0.1f);
    }

    void Update()
    {
        
    }

    private void Player_Regen()
    {
        GameManager.Instance.player_health.Health_Regen(GameManager.Instance.player_health.regen);
    }
    public IEnumerator Player_Takes_Damage(int damage)
    {
        GameManager.Instance.player_health.Damage_Unit(damage);
        if(GameManager.Instance.player_health.health <= 0)
        {
            Player_Dies();
        }
        yield return new WaitForSeconds(0.5f);
    }
    private void Player_Heals(int heal)
    {
        GameManager.Instance.player_health.Heal_Unit(heal);
    }

    private void Player_Dies()
    {
        On_Player_Death?.Invoke(this);
        
    }
}
