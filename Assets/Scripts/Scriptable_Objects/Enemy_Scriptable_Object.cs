using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_scriptable_object", menuName = "Scriptable_objects/Enemy")]
public class Enemy_Scriptable_Object : ScriptableObject
{
    public float health;
    public float max_health;
    public float min_damage;
    public float max_damage;
    public float crit_multiplier;
    public float crit_chance;
    public float health_regen;
    public int xp_reward;
    public float move_speed;
    public int level;
    public float aggro_distance;
    public Enemy_Attack_Scriptable_Object enemy_attack_type;
}
