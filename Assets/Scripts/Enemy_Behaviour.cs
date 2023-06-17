using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Character;
using UI;

namespace Enemy
{
    public class Enemy_Behaviour : MonoBehaviour
    {
        public Enemy_Scriptable_Object enemy;
        public GameObject character;
        [SerializeField] private float distance;
        public Unit_Health enemy_health;
        public static event Action<Enemy_Behaviour> On_Enemy_Death;
        public bool alive = true;
        int enemy_xp;
        public Unit_Damage enemy_damage;
        private UI_Manager ui_manager;

        private void Start()
        {
            ui_manager = UI_Manager.Instance;
            Spawn();
        }
        private void OnMouseOver()
        {
            ui_manager.Update_Enemy_Bar(gameObject);
        }
        void Update()
        {
            if (alive)
            {
                distance = Vector2.Distance(transform.position, character.transform.position);
                Vector2 direction = character.transform.position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                if (distance < enemy.aggro_distance)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, character.transform.position, enemy.move_speed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                }
            }

        }
        public void Enemy_Takes_Damage(int damage)
        {
            enemy_health.Damage_Unit(damage);
            ui_manager.Update_Enemy_Bar(gameObject);
            Debug.Log("Enemy health: " + enemy_health.health);
            if (alive && enemy_health.health <= 0)
            {
                Die();
            }
        }

        public void Spawn()
        {
            character = GameObject.Find("Player");
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
                if (GameManager.Instance.character_alive == true)
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
            GetComponent<BoxCollider2D>().enabled = false;
            GameManager.Instance.character_level.Gain_Xp(enemy_xp);
            alive = false;
        }
    }
}
