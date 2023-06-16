using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Enemy;
using Character;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text heatlh_text;
    public TMP_Text enemy_text;

    // Start is called before the first frame update
    void Start()
    {
        heatlh_text.text = "Player health: " + GameManager.Instance.player_health.health.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Update_Health_Text()
    {
        heatlh_text.text = "Player health: " + GameManager.Instance.player_health.health.ToString();
    }
    public void Update_Enemy_Bar(GameObject enemy)
    {
        enemy_text.text = enemy.name + "<br>" + enemy.GetComponent<Enemy_Behaviour>().enemy_health.health.ToString();
    }
}
