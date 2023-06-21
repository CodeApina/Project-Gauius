using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable_objects/Items/Weapon")]
public class Weapon_Scriptable_Object : ScriptableObject
{
    public Sprite item_sprite;
    public float base_min_damage;
    public float base_max_damage;
    public float base_crit_chance;
    public float base_attack_speed;
    public List<Item_Tag> tags;
    public MonoBehaviour weapon_controller;
}
