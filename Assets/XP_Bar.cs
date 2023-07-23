using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using Character;

namespace UI
{
    public class XP_Bar : MonoBehaviour
    {
        public TMP_Text percentage;
        public TMP_Text level;
        public Image bar;
        public GameObject player;
        private Character_Level_Handler player_level;
        // Start is called before the first frame update
        void Start()
        {
            player_level = player.GetComponent<Character_Level_Handler>();
            percentage.text = "0%";
            bar.fillAmount = 0;
        }

        void Update()
        {
            if (player_level.current_xp != 0)
            {
                percentage.text = Mathf.FloorToInt((player_level.current_xp - player_level.last_level_xp) / player_level.current_xp_to_next_level * 100) + "%";
                bar.fillAmount = ((player_level.current_xp - player_level.last_level_xp) / player_level.current_xp_to_next_level);
            }
            
            level.text = "Level: " + player_level.current_level;
        }
    }
}

