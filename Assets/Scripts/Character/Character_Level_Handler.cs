using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character_Level_Handler
    {
        int current_level;
        int current_xp;
        int current_xp_to_next_level;
        public static event Action<Character_Level_Handler> OnLevelChange;

        public int level
        {
            get { return current_level; }
            set { current_level = value; }
        }
        public int xp
        {
            get { return current_xp; }
            set { current_xp = value; }
        }
        public int xp_to_next_level
        {
            get { return current_xp_to_next_level; }
            set { current_xp_to_next_level = value; }
        }
        public Character_Level_Handler(int level, int xp, int xp_to_next_level)
        {
            current_level = level;
            current_xp = xp;
            current_xp_to_next_level = xp_to_next_level;
        }
        public void Level_Up()
        {
            var player_damage = GameManager.Instance.character_damage;
            player_damage.damage_min = player_damage.damage_min * current_level;
            player_damage.damage_max = player_damage.damage_max * current_level;
        }
        public void Gain_Xp(int xp)
        {
            current_xp += xp;
            if (current_xp >= current_xp_to_next_level)
            {
                current_level++;
                OnLevelChange?.Invoke(this);
            }
        }
    }
}