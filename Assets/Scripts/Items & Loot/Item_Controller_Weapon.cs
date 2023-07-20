using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;

public class Item_Controller_Weapon : MonoBehaviour
{
    private Item item;
    public Weapon_Item_Stats weapon_stats;
    [SerializeField] private float min_damage;
    [SerializeField] private float max_damage;
    [SerializeField] private float attack_speed;
    [SerializeField] private float crit_chance;
    [SerializeField] public List<Item_Modifier> modifiers;
    [SerializeField] private float level;
    [SerializeField] private string rarity;
    public Weapon_Scriptable_Object weapon_object;
    public Sprite item_sprite;
    public SpriteRenderer item_renderer;
    public List<Item_Tag> tags;
    // Start is called before the first frame update
    void Start()
    {
        if (weapon_stats != null)
        {
            min_damage = weapon_stats.min_damage_number;
            max_damage = weapon_stats.max_damage_number;
            attack_speed = weapon_stats.attack_speed;
            crit_chance = weapon_stats.crit_chance;
            item_renderer = gameObject.GetComponent<SpriteRenderer>();
            item_renderer.sprite = item_sprite;
            weapon_stats = (Weapon_Item_Stats)item.Generate_Item(26f);
            weapon_stats.min_damage_number = weapon_object.base_min_damage;
            weapon_stats.max_damage_number = weapon_object.base_max_damage;
            weapon_stats.crit_chance = weapon_object.base_crit_chance;
            weapon_stats.attack_speed = weapon_object.base_attack_speed;
            tags = weapon_stats.tags;
            modifiers = weapon_stats.modifiers;
            level = weapon_stats.level;
            rarity = weapon_stats.rarity;
            weapon_stats.min_damage_number += Modifier_Flat_Effect_Calculator(Affected_Atribute.damage_flat);
            weapon_stats.max_damage_number += Modifier_Flat_Effect_Calculator(Affected_Atribute.damage_flat);
            weapon_stats.crit_chance += Modifier_Flat_Effect_Calculator(Affected_Atribute.crit_chance);
            foreach (var value in Modifier_Percent_Effect_Calculator(Affected_Atribute.damage_percent))
            {
                weapon_stats.min_damage_number = weapon_stats.min_damage_number * (1 + value / 100);
                weapon_stats.max_damage_number = weapon_stats.max_damage_number * (1 + value / 100);
            }
            foreach (var value in Modifier_Percent_Effect_Calculator(Affected_Atribute.attack_speed))
            {
                weapon_stats.attack_speed = weapon_stats.attack_speed * (1 + value / 100);
            }
        }
        
    }
    private List<float> Modifier_Percent_Effect_Calculator(Affected_Atribute atribute)
    {
        List<float> modifier_percent = new List<float>();
        foreach (var modifier in weapon_stats.modifiers)
        {
            if (modifier.affected_atribute == atribute)
            {
                modifier_percent.Add(modifier.value);
            }
        }
        return modifier_percent;

    }
    private float Modifier_Flat_Effect_Calculator(Affected_Atribute atribute)
    {
        float modifier_flat = 0f;
        foreach (var modifier in weapon_stats.modifiers)
        {
            if (modifier.affected_atribute == atribute)
            {
                modifier_flat += modifier.value;
            }
        }
        return modifier_flat;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
