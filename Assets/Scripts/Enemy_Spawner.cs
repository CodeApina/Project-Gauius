using Enemy;
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
        GameObject enemy_type = enemy_types[Random.Range(0, enemy_types.Count)];
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
            Vector2 location = new Vector2(pack.transform.position.x + Random.Range(-4f, 4f), pack.transform.position.y + Random.Range(-4f, 4f));
            var enemy = Instantiate(enemy_type,location, pack.transform.rotation ,pack.transform);
            enemy.GetComponent<Enemy_Behaviour>().level = area_level;
            enemy.GetComponent<Enemy_Behaviour>().loot = Loot_Manager.Instance.Generate_Loot(area_level);
        }
    }
}
