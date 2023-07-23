using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Enemy;
using Character;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;

namespace UI
{
    public class UI_Manager : MonoBehaviour
    {
        public static UI_Manager Instance{ get; private set; }
        public TMP_Text player_health_text;
        public TMP_Text player_mana_text;
        public TMP_Text enemy_text;
        public Image enemy_bar;
        public GameObject enemy_bar_parent;
        [SerializeField]
        public GameObject enemy; 
        public float max_distance_for_enemy_bar = 50f;
    
        // Start is called before the first frame update
        void Start()
        {
            player_health_text.text = "Player enemy_health: " + GameManager.Instance.character_health.health.ToString();
            player_mana_text.text = "Player mana: " + GameManager.Instance.character_mana.mana.ToString();
        }
    
        // Update is called once per frame
        void Update()
        {
            if (enemy != null)
            {
                if (Vector2.Distance(enemy.transform.position, GameObject.Find("Player").transform.position) >= max_distance_for_enemy_bar)
                {

                    enemy_text.text = string.Empty;
                }
            }
            if (enemy == null || !enemy.GetComponent<Enemy_Behaviour>().alive)
            {
                enemy_bar_parent.SetActive(false);
            }
                
        }
    
        public void Update_Health_Text()
        {
            player_health_text.text = "Player enemy_health: " + GameManager.Instance.character_health.health.ToString();
        }
        public void Update_Mana_Text()
        {
            player_mana_text.text = "Player mana: " + GameManager.Instance.character_mana.mana.ToString();
        }
        public void Update_Enemy_Bar(GameObject enemy)
        {
            enemy_bar_parent.SetActive(true);
            enemy_bar.fillAmount = enemy.GetComponent<Enemy_Behaviour>().enemy_health.health / enemy.GetComponent<Enemy_Behaviour>().enemy_health.max_health;
            enemy_text.text = enemy.name;
        }
        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
            DontDestroyOnLoad(this);
        }
    }
}
