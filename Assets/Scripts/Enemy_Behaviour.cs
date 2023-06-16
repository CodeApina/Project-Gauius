using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Character;

namespace Enemy
{
    public class Enemy_Behaviour : MonoBehaviour
    {
        public Enemy_Scriptable_Object enemy;
        public GameObject player;
        private float distance;
        public Unit_Health enemy_health;
        public static event Action<Enemy_Behaviour> On_Enemy_Death;
        public bool alive = true;
        public float move_speed = 1f;
        int enemy_xp;
        public Unit_Damage enemy_damage;

        private void Start()
        {
            Spawn();
        }
        private void OnMouseOver()
        {
            GameManager.Instance.ui_manager.Update_Enemy_Bar(gameObject);
        }
        void Update()
        {
            if (alive)
            {
                distance = Vector2.Distance(transform.position, player.transform.position);
                Vector2 direction = player.transform.position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                if (distance < enemy.aggro_distance)
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

        public void Spawn()
        {
            player = GameObject.Find("Player");
            enemy_health = new Unit_Health(enemy.health * enemy.level, enemy.max_health * enemy.level, enemy.health_regen * enemy.level);
            enemy_damage = new Unit_Damage(enemy.min_damage * enemy.level, enemy.max_damage * enemy.level, enemy.crit_multiplier, enemy.crit_chance * enemy.level);
            enemy_xp = enemy.xp_reward * enemy.level;
            Debug.Log(enemy_health.health);
        }
        // When hit's player
        private void OnCollisionStay2D(Collision2D collision)
        {

            if (collision.gameObject.TryGetComponent<Character_Behaviour>(out Character_Behaviour player_model))
            {
                if (GameManager.Instance.player_alive == true)
                {
                    player_model.Character_Takes_Damage(enemy_damage.Damage_Calculation());
                }
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
}
