using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character_Skills : MonoBehaviour
    {
        public Skills_Scriptable_Object skill;
        public float duration;
        public float cooldown;
        public KeyCode key;
        public enum Skill_State
        {
            ready,
            active,
            cooldown
        }
        public Character_Skills(Skills_Scriptable_Object skill, float duration, float cooldown, Skill_State state, KeyCode key)
        {
            this.skill = skill;
            this.duration = duration;
            this.cooldown = cooldown;
            this.state = state;
            this.key = key;
        }
        Skill_State state = Skill_State.ready;

        
        void Update()
        {
            switch (state)
            {
                case Skill_State.ready:
                    if (Input.GetKey(key))
                    {
                        skill.Activate(gameObject);
                        state = Skill_State.active;
                    }
                    break;
                case Skill_State.active:
                    if (duration > 0)
                    {
                        duration -= Time.deltaTime;
                    }
                    else
                    {
                        state = Skill_State.cooldown;
                        cooldown = skill.base_cooldown;
                    }
                    break;
                case Skill_State.cooldown:
                    if (cooldown > 0)
                    {
                        cooldown -= Time.deltaTime;
                    }
                    else
                    {
                        state = Skill_State.ready;
                    }
                    break;
            }

        }
        public void Skill_Innitialization()
        {

        }
    }
}
