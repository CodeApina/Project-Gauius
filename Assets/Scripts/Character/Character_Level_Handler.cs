using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Character
{
    public class Character_Level_Handler : MonoBehaviour
    {
        public int current_level;
        public float current_xp;
        public float current_xp_to_next_level;
        public float last_level_xp = 0;
        public static event Action<Character_Level_Handler> OnLevelChange;

        public void Level_Up()
        {
            var player_damage = GameManager.Instance.character_damage;
            player_damage.damage_min = player_damage.damage_min * (1.25f * current_level);
            player_damage.damage_max = player_damage.damage_max * (1.25f * current_level);
            current_xp_to_next_level = current_xp * current_level;

        }
        public void Gain_Xp(int xp)
        {
            current_xp += xp;
            if (current_xp >= current_xp_to_next_level)
            {
                last_level_xp = current_xp;
                current_level++;
                current_xp_to_next_level = current_xp_to_next_level * current_level;
            }
        }
    }
}