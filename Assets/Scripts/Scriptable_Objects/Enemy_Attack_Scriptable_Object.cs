using UnityEditor.UIElements;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_attack_scriptable_object", menuName = "Scriptable_objects/Enemy_attack")]
public class Enemy_Attack_Scriptable_Object : ScriptableObject
{
    public float min_attack_damage;
    public float max_attack_damage;
    public float attack_range;
    public string attack_type;
}
