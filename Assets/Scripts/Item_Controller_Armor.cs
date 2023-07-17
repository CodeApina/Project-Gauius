using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Controller_Armor : MonoBehaviour
{
    private Item item;
    public Armor_Item_Stats weapon_stats;
    public Armor_Scriptable_Object item_object;
    public Sprite item_sprite;
    public SpriteRenderer item_renderer;
    public List<Item_Tag> tags;
    [SerializeField] public List<Item_Modifier> modifiers;
    public float level;
    public string rarity;
    // Start is called before the first frame update
    void Start()
    {
        item_renderer = gameObject.GetComponent<SpriteRenderer>();
        item_renderer.sprite = item_sprite;
        weapon_stats = (Armor_Item_Stats)item.Generate_Item(26f);
        tags = weapon_stats.tags;
        modifiers = weapon_stats.modifiers;
        level = weapon_stats.level;
        rarity = weapon_stats.rarity;
        float modifier_flat_effect = 0f;
        List<float> modifier_percent_effect = new List<float>();
        foreach (Item_Modifier modifier in weapon_stats.modifiers)
        {
            switch (modifier.affected_atribute)
            {
                case Affected_Atribute.damage_percent:
                    modifier_percent_effect.Add(modifier.value);
                    break;
                case Affected_Atribute.damage_flat:
                    modifier_flat_effect += modifier.value;
                    break;
            }

        }
        weapon_stats.armor_value += modifier_flat_effect;
        foreach (var value in modifier_percent_effect)
        {
            weapon_stats.armor_value = weapon_stats.armor_value * (1 + value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
