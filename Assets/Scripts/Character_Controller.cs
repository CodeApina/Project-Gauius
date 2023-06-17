using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Character
{
    public class Character_Controller : MonoBehaviour
    {
        public float move_speed = 5f;
        public Vector2 target;
        private Vector2 aim_target;
        public float attack_speed = 1.5f;
        public bool can_attack = true;
        public Rigidbody2D rb;
        public Weapon weapon;
        private bool moving;
        private bool movement_ability_active = false;
        private float movement_ability_speed;
        // Start is called before the first frame update
        void Start()
        {
            target = transform.position;
        }
        private void OnEnable()
        {
            Character_Behaviour.On_Player_Death += Handle_RB_On_Player_Death;
        }
        private void OnDisable()
        {
            Character_Behaviour.On_Player_Death -= Handle_RB_On_Player_Death;
        }
        // Update is called once per frame
        void Update()
        {
            aim_target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            if (GameManager.Instance.player_alive && !movement_ability_active)
            {
                if (Input.GetMouseButton(0))
                {
                    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    moving = true;
                }
                if (moving && (Vector2)transform.position != target)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target, move_speed * Time.deltaTime);
                }
                else
                    moving = false;
                if (Input.GetMouseButton(1))
                {
                    if (can_attack)
                    {
                        weapon.Fire();
                        can_attack = false;
                        StartCoroutine(Attack_Delay());
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
                transform.position = Vector2.MoveTowards(transform.position, target, movement_ability_speed * Time.deltaTime);
                if ((Vector2)transform.position == target)
                {
                    movement_ability_active = false;
                }
            }

        }
        public void Teleport()
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(target.x, target.y);
        }
        public void Movement_Ability(float speed)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movement_ability_active = true;
            movement_ability_speed = speed;
        }

        private IEnumerator Attack_Delay()
        {
            yield return new WaitForSeconds(1 / attack_speed);
            can_attack = true;
        }


        void Handle_RB_On_Player_Death(Character_Behaviour player)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
