using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using System.Linq;

namespace UI
{
    public class Skill_Cooldown : MonoBehaviour
    {
        public Keybindings_Scriptable_Object keybinding;
        public string skill_button_name;
        public Keybinding_Actions action;
        public Image dark_mask;
        public TMP_Text cooldown_number;
        public TMP_Text mana_cost_number;
        public TMP_Text skill_name_text;
        public TMP_Text button_name_text;

        [SerializeField] private Skills_Scriptable_Object skill;
        [SerializeField] private GameObject weapon_holder;
        private Image skill_image;
        private AudioSource skill_audio_source;
        private float cooldown_duration;
        private float next_ready_time;
        private float cooldown_time_left;

        // Start is called before the first frame update
        void Start()
        {
            Initialize(skill, weapon_holder);
        }

        public void Initialize(Skills_Scriptable_Object selected_skill, GameObject weapon)
        {
            skill = selected_skill;
            mana_cost_number.text = skill.base_mana_cost.ToString();
            skill_name_text.text = skill.name;
            button_name_text.text = keybinding.ToString();
            skill_image = GetComponent<Image>();
            skill_audio_source = GetComponent<AudioSource>();
            skill_image.sprite = skill.skill_sprite;
            dark_mask.sprite = skill.skill_sprite;
            cooldown_duration = skill.base_cooldown;
            skill.Innitialize(weapon_holder);
            Skill_Ready();
        }

        // Update is called once per frame
        void Update()
        {
            bool cooldown_complete = (Time.time > next_ready_time);
            if (cooldown_complete)
            {
                Skill_Ready();
                if (Keybinding_Manager.Instance.Get_Key_Down(action))
                {
                    Skill_Used();
                }
            }
            else
            {
                Cooldown();
            }
        }
        private void Skill_Ready()
        {
            cooldown_number.enabled = false;
            dark_mask.enabled = false;
        }

        private void Cooldown()
        {
            cooldown_time_left -= Time.deltaTime;
            float rounded_cooldown = Mathf.Round(cooldown_time_left);
            cooldown_number.text = rounded_cooldown.ToString();
            dark_mask.fillAmount = (cooldown_time_left / cooldown_duration);
        }

        private void Skill_Used()
        {
            next_ready_time = cooldown_duration + Time.time;
            cooldown_time_left = cooldown_duration;
            cooldown_number.enabled = true;
            dark_mask.enabled = true;

            //skill_audio_source.clip = skill.skill_audio;
            //skill_audio_source.Play();
            skill.Trigger_Skill();
            }
    }
}

