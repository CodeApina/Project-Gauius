using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Loot_Manager : MonoBehaviour
{
    public static Loot_Manager Instance;
    public GameObject items;
    public GameObject ui_element;
    public GameObject item_base;
    public List<Weapon_Scriptable_Object> weapon_models;
    public List<Armor_Scriptable_Object> armor_models;
    public List<Item_Modifiers_Scriptable_Object> modifiers;
    
    public List<GameObject> Generate_Loot(float monster_level)
    {
        List<GameObject> loot = new List<GameObject>();
        float min_loot_amount = Mathf.Round(1 * (1 + monster_level / 10));
        float max_loot_amount = Mathf.Round(5 * (1+ monster_level / 10));
        float loot_amount = Random.Range(min_loot_amount, max_loot_amount);
        for (int i = 0; i < loot_amount; i++)
        {
            GameObject item_being_generated = Instantiate(item_base);
            item_being_generated.AddComponent<Item>();
            item_being_generated.GetComponent<Item>().stats = item_being_generated.GetComponent<Item>().Generate_Item(monster_level);
            item_being_generated.name = item_being_generated.GetComponent<Item>().stats.name;
            GameObject ui = Instantiate(ui_element);
            ui.transform.parent = item_being_generated.transform;
            ui.GetComponent<Item_UI>().image.color = item_being_generated.GetComponent<Item>().stats.color;
            ui.GetComponent<Item_UI>().name_field.text = item_being_generated.GetComponent<Item>().stats.name;
            item_being_generated.transform.parent = items.transform;
            item_being_generated.SetActive(false);
            loot.Add(item_being_generated);
        }
        return loot;
    }
    public void Drop_Loot(List<GameObject> loot, GameObject enemy)
    {
        foreach (GameObject current_item in loot)
        {
            
            current_item.transform.position = enemy.transform.position;
            current_item.transform.rotation = Quaternion.identity;
            current_item.SetActive(true);
        }
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
        item_base = new GameObject();
    }
}
