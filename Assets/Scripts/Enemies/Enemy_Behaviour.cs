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
        public Unit_Health enemy_health;
        public int level;
        [SerializeField]
        public List<GameObject> loot;
        public static event Action<Enemy_Behaviour> On_Enemy_Death;
        public bool alive = true;
        public int enemy_xp_reward;
        public Rigidbody2D rb;
        public Unit_Damage enemy_damage;
        private UI_Manager ui_manager;
        public bool agroed = false;
        [SerializeField]
        private bool agro_message_sent = false;
        public Vector2 direction;

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
            if (player == null)
            {
                player = GameManager.Instance.character;
            }
            
            if(!agro_message_sent && agroed)
            {
                SendMessageUpwards("Child_Agro");
                agro_message_sent = true;

            }
            if (!agroed)
            {
                float distance = Vector2.Distance(transform.position, player.transform.position);
                direction = (player.transform.position - transform.position).normalized;
                Debug.DrawRay(transform.position, direction, Color.green);

                if (distance <= enemy.aggro_distance + 10)
                {
                    agroed = Ray_Cast(direction);
                    
                }
            }
            
        }
        private void FixedUpdate()
        {
            if (agroed)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemy.move_speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * direction);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }


        }
        bool Ray_Cast(Vector2 angle)
        {
            // array of angles and foreach for each, one angle for diagonals and one for horizontals and verticals?
            bool value = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, angle, enemy.aggro_distance, 1 << LayerMask.NameToLayer("Ray_Cast_Enabled"));
            if(hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    value = true;
                }
                
            }
            return value;
        }

        public void Agro()
        {
            agroed = true;
        }
        public void Enemy_Takes_Damage(int damage, GameObject enemy)
        {
            if (!agroed)
            {
                agroed = true;
                SendMessageUpwards("Child_Agro");
            }
            UI_Manager.Instance.Update_Enemy_Bar(enemy);
            UI_Manager.Instance.enemy = gameObject;
            enemy_health.Damage_Unit(damage);
            ui_manager.Update_Enemy_Bar(gameObject);
            if (enemy_health.health <= 0)
            {
                Die();
            }
        }

        public void Spawn()
        {
            player = GameObject.Find("Player");
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
            alive = false;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            On_Enemy_Death?.Invoke(this);
            GetComponent<BoxCollider2D>().enabled = false;
            GameManager.Instance.character.GetComponent<Character_Level_Handler>().Gain_Xp(enemy_xp_reward);
            Loot_Manager.Instance.Drop_Loot(loot, gameObject);
        }
    }
}
