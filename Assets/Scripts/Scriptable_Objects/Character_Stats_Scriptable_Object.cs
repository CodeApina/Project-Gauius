using UnityEngine;

[CreateAssetMenu(fileName = "Player_scriptable_object", menuName = "Scriptable_objects/Charactrer")]
public class Character_Stats_Scriptable_Object : ScriptableObject
{
    public float health;
    public float max_health;
    public float mana;
    public float max_mana;
    public float health_regen;
    public float health_regen_delay;
    public float mana_regen;
    public int move_speed;
    public float attack_speed;
}
