using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Character
{
    public class Character_Controller : MonoBehaviour
    {
        public float move_speed = 5f;
        public Vector2 move_target;
        private Vector2 aim_target;
        public float attack_speed = 1.5f;
        public bool can_attack = true;
        [HideInInspector] public float fire_force = 40f;
        public GameObject projectile_prefab;
        public Rigidbody2D rb;
        public Weapon weapon;
        private bool moving;
        private bool movement_ability_active = false;
        private float movement_ability_speed;
        // Start is called before the first frame update
        void Start()
        {
            move_target = transform.position;
        }
        private void OnEnable()
        {
            Character_Behaviour.On_Character_Death += Handle_RB_On_Character_Death;
        }
        private void OnDisable()
        {
            Character_Behaviour.On_Character_Death -= Handle_RB_On_Character_Death;
        }
        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.character_alive)
            {
                aim_target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                if (GameManager.Instance.character_alive && !movement_ability_active)
                {
                    if (Input.GetMouseButton(0))
                    {
                        move_target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        moving = true;
                    }
                    if ((Vector2)transform.position == move_target)
                    {
                        moving = false;
                    }

                    if (Input.GetMouseButton(1) && can_attack)
                    {
                        weapon.Fire(projectile_prefab, fire_force);
                        can_attack = false;
                        StartCoroutine(Attack_Delay());
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Loot_Manager.Instance.Generate_Loot(20);
                    }
                }
            }
            
        }
        private void FixedUpdate()
        {
            Vector2 aim_direction = aim_target;
            float aim_angle = Mathf.Atan2(aim_direction.y, aim_direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aim_angle;
            if (movement_ability_active)
            {
                transform.position = Vector2.MoveTowards(transform.position, move_target, movement_ability_speed * Time.deltaTime);
                if ((Vector2)transform.position == move_target)
                {
                    movement_ability_active = false;
                }
            }
            if (moving && (Vector2)transform.position != move_target)
            {
                transform.position = Vector2.MoveTowards(transform.position, move_target, move_speed * Time.deltaTime);
            }

        }
        public void Teleport()
        {
            move_target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(move_target.x, move_target.y);
        }
        public void Movement_Ability(float speed, float range, bool move_to_range)
        {
            Vector2 ability_target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distance = Vector2.Distance(transform.position, move_target);
            if (distance > range && move_to_range)
            {
                move_target = (Vector2)transform.position + ability_target * (distance - range);
                moving = true;
                Wait_For_Range(range);
                
            }
            if (distance <= range && move_to_range || !move_to_range)
            {
                movement_ability_active = true;
                movement_ability_speed = speed;
            }
        }
        IEnumerator Wait_For_Range(float range)
        {
            yield return new WaitUntil(() => Vector2.Distance(transform.position,move_target) == range);
        }
        private IEnumerator Attack_Delay()
        {
            yield return new WaitForSeconds(1 / attack_speed);
            can_attack = true;
        }


        void Handle_RB_On_Character_Death(Character_Behaviour character)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
