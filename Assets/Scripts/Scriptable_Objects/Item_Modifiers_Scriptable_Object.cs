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
}
public enum Affected_Atribute
{
    health,
    health_percent,
    health_regen,
    mana,
    mana_percent,
    mana_regen,
    damage,
    damage_percent,
    armor,
    armor_percent,
    strength,
    attack_speed,
    crit_chance,
    crit_multiplier
}