using UnityEngine;

[CreateAssetMenu(fileName = "Skills_Scriptable_Object", menuName = "Scriptable_objects/Ranged Skill")]
public class Ranged_Scriptable_Object : Skills_Scriptable_Object
{
    public float min_base_damage;
    public float max_base_damage;
    public float base_crit_chance;
    public float base_crit_multiplier;
    public float base_attack_speed;
    public string damage_type;
}
