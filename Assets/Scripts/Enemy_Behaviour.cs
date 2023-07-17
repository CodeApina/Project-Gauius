using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Character;
using UI;
using UnityEngine.UIElements;

namespace Enemy
{
    public class Enemy_Behaviour : MonoBehaviour
    {
        public Enemy_Scriptable_Object enemy;
        public GameObject player;
        [SerializeField] private float distance;
        public Unit_Health enemy_health;
        public GameObject point_of_ray;
        public int level;
        [SerializeField]
        public List<GameObject> loot;
        public static event Action<Enemy_Behaviour> On_Enemy_Death;
        public bool alive = true;
        int enemy_xp;
        public Rigidbody2D rb;
        public Unit_Damage enemy_damage;
        private UI_Manager ui_manager;
        public bool agroed = false;
        private Vector2 direction;
        public Vector2 angle;

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
            point_of_ray.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            float angle_float = Vector2.Angle(point_of_ray.transform.position, (Vector2)player.transform.position);
            angle = new Vector2(Mathf.Cos(angle_float * Mathf.Deg2Rad), Mathf.Sin(angle_float * Mathf.Deg2Rad)).normalized;
            Debug.DrawLine(point_of_ray.transform.position, angle, Color.red);
            if (alive && distance <= enemy.aggro_distance + 10)
            {
                agroed = Ray_Cast(angle);
            }
            if (player == null) 
            {
                player = GameManager.Instance.character;
            }
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
        }
        private void FixedUpdate()
        {
            if (agroed && alive)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemy.move_speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
            if (!alive || !agroed)
            {
                rb.velocity = Vector3.zero;
                transform.position = transform.position;
            }


        }
        bool Ray_Cast(Vector3 angle)
        {
            // array of angles and foreach for each, one angle for diagonals and one for horizontals and verticals?
            bool value = false;
            RaycastHit2D hit = Physics2D.Raycast(point_of_ray.transform.position, angle, enemy.aggro_distance, 1 << LayerMask.NameToLayer("Ray_Cast_Enabled"));
            if (agroed)
            {
                return agroed;
            }
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    value = true;
                }
                
            }
            return value;
        }
        public void Enemy_Takes_Damage(int damage, GameObject enemy)
        {
            UI_Manager.Instance.Update_Enemy_Bar(enemy);
            enemy_health.Damage_Unit(damage);
            ui_manager.Update_Enemy_Bar(gameObject);
            if (alive && enemy_health.health <= 0)
            {
                Die();
            }
        }

        public void Spawn()
        {
            player = GameObject.Find("Player");
            loot = Loot_Manager.Instance.Generate_Loot(level);
            enemy_health = new Unit_Health(enemy.health * enemy.level, enemy.max_health * enemy.level, enemy.health_regen * enemy.level);
            enemy_damage = new Unit_Damage(enemy.min_damage * enemy.level, enemy.max_damage * enemy.level, enemy.crit_multiplier, enemy.crit_chance * enemy.level);
            enemy_xp = enemy.xp_reward * enemy.level;
            if (loot.Count != 0)
            {
                Debug.Log(loot);
            }
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
            Loot_Manager.Instance.Drop_Loot(loot, gameObject);
            alive = false;
        }
    }
}
