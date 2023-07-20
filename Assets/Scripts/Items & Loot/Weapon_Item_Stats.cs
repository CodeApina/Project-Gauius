using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Weapon_Item_Stats : Item_Stats
{
    protected float base_min_damage_number;
    protected float base_max_damage_number;
    protected float base_crit_chance;
    protected float base_attack_speed;
    protected string base_damage_type;
    
    public float min_damage_number
    {
        get { return base_min_damage_number; }
        set { base_min_damage_number = min_damage_number; }
    }
    public float max_damage_number
    {
        get { return base_max_damage_number; }
        set { base_max_damage_number = max_damage_number; }
    }
    public string damage_type
    {
        get { return base_damage_type; }
        set { base_damage_type = value; }
    }
    public float crit_chance
    {
        get { return base_crit_chance; }
        set { base_crit_chance = value; }
    }
    public float attack_speed
    {
        get { return base_attack_speed; }
        set { base_attack_speed = value; }
    }
    
    public Weapon_Item_Stats(float level, Color color, List<Item_Modifier> modifiers = null, List<Item_Tag> tags = null, string name = "default", int modifier_number = 112, int min_modifier_number = 111, int max_modifier_number = 112, float level_required = 112, string rarity = "default", float min_damage_number = 112f ,float max_damage_number = 112f , string damage_type = "default", string type = "default", float crit_chance = 0f, float attack_speed = 1.5f)
    {
        item_name = name;
        item_modifier_number = modifier_number;
        item_min_modifier_number = min_modifier_number;
        item_max_modifier_number = max_modifier_number;
        item_level_required = level_required;
        item_level = level;
        item_modifiers = modifiers;
        base_min_damage_number = min_damage_number;
        base_damage_type = damage_type;
        item_tags = tags;
        base_max_damage_number = max_damage_number;
        base_crit_chance = crit_chance;
        base_attack_speed = attack_speed;
        item_color = color;
    }
}
