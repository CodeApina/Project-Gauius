using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Scriptable_objects/Items/Armor")]
public class Armor_Scriptable_Object : ScriptableObject
{
    public float base_armor_value;
    public Sprite item_sprite;
    public List<Item_Tag> tags;
    public MonoBehaviour armor_controller;
}
