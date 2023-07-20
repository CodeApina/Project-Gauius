using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_Item_Stats : Item_Stats 
{
    protected string item_equip_slot;
    protected float item_armor_value;

    public float armor_value
    {
        get { return item_armor_value; }
        set { item_armor_value = value; }
    }
    
    public string equip_slot
    {
        get { return item_equip_slot; }
        set { item_equip_slot = value; }
    }
    public Armor_Item_Stats(float level, Color color, List<Item_Modifier> modifiers = null, List<Item_Tag> tags = null, string type = "default" , string name = "default", int modifier_number = 112, int min_modifier_number = 111, int max_modifier_number = 112, float level_required = 112f,string rarity = "default", string equip_slot = "default", float armor_value = 112f)
    {
        item_name = name;
        item_modifier_number = modifier_number;
        item_type = type;
        item_min_modifier_number = min_modifier_number;
        item_max_modifier_number = max_modifier_number;
        item_level = level;
        item_level_required = level_required;
        item_modifiers = modifiers;
        item_tags = tags;
        item_equip_slot = equip_slot;
        item_armor_value = armor_value;
        item_color = color;
    }
}
