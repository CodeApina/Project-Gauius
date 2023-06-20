using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Loot_Manager : MonoBehaviour
{
    public static Loot_Manager Instance;
    public Item item = new Item();
    public Dictionary<int,Item_Modifiers_Scriptable_Object> modifier_dictionary = new Dictionary<int, Item_Modifiers_Scriptable_Object>();
    public List<Item_Modifiers_Scriptable_Object> modifiers;
    
    public List<Item_Stats> Generate_Loot(float monster_level)
    {
        float min_loot_amount = 1 * monster_level / 10;
        float max_loot_amount = 10 * monster_level / 10;
        if (min_loot_amount < 1)
        {
            min_loot_amount = 1;
        }
        float loot_amount = Random.Range(min_loot_amount, max_loot_amount);
        for (int i = 0; i < loot_amount; i++)
        {
            item.Generate_Item(monster_level);
        }
        return null;
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
    }
}
