using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Modifier", menuName = "Scriptable_objects/Modifiers")]
public class Item_Modifiers_Scriptable_Object : ScriptableObject
{
    public string modifier_name;
    public List<Item_Tag> tags;
    public float min_value;
    public float max_value;
    public Affected_Atribute affected_atribute;
    public float rank;
}
public enum Affected_Atribute
{
    health_flat,
    health_percent,
    health_regen,
    mana_flat,
    mana_percent,
    mana_regen,
    damage_flat,
    damage_percent,
    armor_flat,
    armor_percent,
    strength_flat,
    attack_speed,
    crit_chance,
    crit_multiplier
}