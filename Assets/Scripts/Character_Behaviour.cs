using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character_Behaviour : MonoBehaviour
    {
        public bool invurnerable = false;
        public bool regen_delay = false;
        public float regen_delay_time = 2f;
        public float damage_delay = 0.5f;
        public static event Action<Character_Behaviour> On_Player_Death;
        void Start()
        {
            InvokeRepeating("Player_Regen",0.2f,0.2f);
        }
        public List<Character_Skills> Skills = new List<Character_Skills>();
        void Update()
        {
        
        }

        private void Player_Regen()
        {
            if (regen_delay) return;
            if (!GameManager.Instance.player_alive) return;
            GameManager.Instance.player_health.Health_Regen(GameManager.Instance.player_health.regen / 5);
            GameManager.Instance.ui_manager.Update_Health_Text();
        }
        public void Character_Takes_Damage(int damage)
        {
            if (invurnerable) return;
            regen_delay = true;
            GameManager.Instance.player_health.Damage_Unit(damage);
            GameManager.Instance.ui_manager.Update_Health_Text();
            if(GameManager.Instance.player_health.health <= 0)
            {
                Player_Dies();
            }
            invurnerable = true;
            StartCoroutine(Regen_Delay_Handler());
            StartCoroutine(Damage_Delay());
        }
        private IEnumerator Regen_Delay_Handler()
        {
            if (!regen_delay) yield break;
            yield return new WaitForSeconds(5);
            regen_delay = false;
        }
        private IEnumerator Damage_Delay()
        {
            yield return new WaitForSeconds(damage_delay);
            invurnerable = false;
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
}