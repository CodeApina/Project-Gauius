using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    public GameObject player;
    public float move_speed;
    private float distance;
    public float aggro_distance;
    public int level = 1;
    public Unit_Health enemy_health;
    public static event Action<Enemy_Behaviour>On_Enemy_Death;
    public static event Action<Enemy_Behaviour>On_Player_Takes_Damage;
    public bool alive = true;
    int enemy_xp;
    public Unit_Damage enemy_damage;

    private void Awake()
    {
        Spawn(1);
    }
    void Update()
    {
        if (alive)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (distance < aggro_distance)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, move_speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }
        
    }
    public void Enemy_Takes_Damage(int damage)
    {
        enemy_health.Damage_Unit(damage);
        Debug.Log("Enemy health: " + enemy_health.health);
        if (alive == true && enemy_health.health <= 0)
        {
            Die();
        }
    }

    public void Spawn(int level)
    {
        player = GameObject.Find("Player");
        enemy_health = new Unit_Health(100f * level, 100f * level, 2.5f * level);
        enemy_damage = new Unit_Damage(10 * level, 2, 5 * level);
        enemy_xp = 100 * level;
        Debug.Log(enemy_health.health);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.TryGetComponent<Player_Behaviour>(out Player_Behaviour player))
        {
            player.Player_Takes_Damage(enemy_damage.Damage_Calculation());
        }
        
    }
    void Damage_Delay()
    {
        
    }
    void Die()
    {
        On_Enemy_Death?.Invoke(this);
        GameManager.Instance.player_level.Gain_Xp(enemy_xp);
        alive = false;
    }
}
