using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Character
{
    public class Character_Behaviour : MonoBehaviour
    {
        public bool invurnerable = false;
        public bool regen_delay = false;
        public float regen_delay_time = 2f;
        public float damage_delay = 0.5f;
        public static event Action<Character_Behaviour> On_Character_Death;
        void Start()
        {
            InvokeRepeating("Character_Health_Regen",0.2f,0.2f);
            InvokeRepeating("Character_Mana_Regen",0.2f,0.2f);
        }
        void Update()
        {
        
        }

        private void Character_Health_Regen()
        {
            if (regen_delay)
            {
                return;
            }
            if (!GameManager.Instance.character_alive)
            {
                return;
            }
            GameManager.Instance.character_health.Health_Regen(GameManager.Instance.character_health.regen / 5);
            UI_Manager.Instance.Update_Health_Text();
        }
        private void Character_Mana_Regen()
        {
            if (!GameManager.Instance.character_alive)
            {
                return;
            }
            GameManager.Instance.character_mana.Mana_Regen(GameManager.Instance.character_mana.mana_regen / 5);
            UI_Manager.Instance.Update_Mana_Text();
        }
        public void Character_Takes_Damage(int damage)
        {
            if (invurnerable) return;
            regen_delay = true;
            GameManager.Instance.character_health.Damage_Unit(damage);
            UI_Manager.Instance.Update_Health_Text();
            if(GameManager.Instance.character_health.health <= 0)
            {
                Character_Dies();
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
        private void Character_Heals(int heal)
        {
            GameManager.Instance.character_health.Heal_Unit(heal);
        }

        private void Character_Dies()
        {
            On_Character_Death?.Invoke(this);
        
        }
    }
}