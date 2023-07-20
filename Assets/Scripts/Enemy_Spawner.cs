using Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public List<GameObject> enemy_types = new List<GameObject>();
    public GameObject pack;
    // Start is called before the first frame update
    void Start()
    {
        Spawn_Enemies(1);
    }

    void Spawn_Enemies(int area_level)
    {
        GameObject enemy_type = enemy_types[UnityEngine.Random.Range(0, enemy_types.Count)];
        pack = Instantiate(pack, transform.position, transform.rotation);
        int pack_size;
        switch (area_level)
        {
            case < 5:
                pack_size = 1; break;
            case <10:
                pack_size = 3; break;
            case < 25:
                pack_size = 5; break;
            case < 50:
                pack_size = 10; break;
            case < 75:
                pack_size = 15; break;
            case < 100:
                pack_size = 20; break;
            default:
                pack_size = 10; break;
        }
        for (int i = 0; i <= pack_size; i++)
        {
            Vector2 location = new Vector2(pack.transform.position.x + UnityEngine.Random.Range(-4f, 4f), pack.transform.position.y + UnityEngine.Random.Range(-4f, 4f));
            var enemy = Instantiate(enemy_type,location, pack.transform.rotation ,pack.transform);
            var enemy_behaviour = enemy.GetComponent<Enemy_Behaviour>();
            enemy_behaviour.level = area_level;
            enemy_behaviour.loot = Loot_Manager.Instance.Generate_Loot(area_level);
            enemy_behaviour.enemy_health = new Unit_Health(enemy_behaviour.enemy.health * enemy_behaviour.enemy.level, enemy_behaviour.enemy.max_health * enemy_behaviour.enemy.level, enemy_behaviour.enemy.health_regen * enemy_behaviour.enemy.level);
            enemy_behaviour.enemy_damage = new Unit_Damage(enemy_behaviour.enemy.min_damage * enemy_behaviour.enemy.level, enemy_behaviour.enemy.max_damage * enemy_behaviour.enemy.level, enemy_behaviour.enemy.crit_multiplier, enemy_behaviour.enemy.crit_chance * enemy_behaviour.enemy.level);
            enemy_behaviour.enemy_xp_reward = enemy_behaviour.enemy.xp_reward * enemy_behaviour.enemy.level;
            enemy.GetComponentInChildren<MonoBehaviour>().enabled = false;
            enemy.GetComponent<MonoBehaviour>().enabled = false;
        }
    }
}
