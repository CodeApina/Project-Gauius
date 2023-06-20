using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_Item_Stats : Item_Stats 
{
    protected string item_equip_slot;
    protected enum type_for_modifiers
    {
        heavy_head_armor,
        heavy_shoulder_armor,
        heavy_chest_armor,
        heavy_wrist_armor,
        heavy_hand_armor,
        heavy_waist_armor,
        heavy_leg_armor,
        heavy_feet_armor,
        medium_head_armor,
        medium_shoulder_armor,
        medium_chest_armor,
        medium_wrist_armor,
        medium_hand_armor,
        medium_waist_armor,
        medium_leg_armor,
        medium_feet_armor,
        light_head_armor,
        light_shoulder_armor,
        light_chest_armor,
        light_wrist_armor,
        light_hand_armor,
        light_waist_armor,
        light_leg_armor,
        light_feet_armor,
        shield
    }
    public static readonly string[] types_armor =
    {
        "heavy-armor",
        "medium-armor",
        "light-armor"
    };
    public static readonly string[] types_equip_slots =
    {
        "head",
        "chest",
        "shoulders",
        "hands",
        "wrists",
        "legs",
        "waist",
        "feet",
        "off-hand"
    };
    protected float item_armor_value;

    public float armor_value
    {
        get { return item_armor_value; }
        set { item_armor_value = value; }
    }
    public static string[] equip_slots
    {
        get { return types_equip_slots; }
    }
    public static string[] types
    {
        get { return types_armor; }
    }
    
    public string equip_slot
    {
        get { return item_equip_slot; }
        set { item_equip_slot = value; }
    }
    public Armor_Item_Stats(float level, List<Item_Modifier> modifiers = null, List<Item_Tag> tags = null, string type = "default" , string name = "default", int modifier_number = 112, int min_modifier_number = 111, int max_modifier_number = 112, float level_required = 112f,string rarity = "default", string equip_slot = "default", float armor_value = 112f)
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
    }
}
