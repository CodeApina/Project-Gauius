using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.CodeDom.Compiler;
using Unity.VisualScripting;
using System.Linq;

public class Item
{
    public Item_Stats Generate_Item(float monster_level)
    {
        float item_level = monster_level;
        float rarity_decider = UnityEngine.Random.Range(1, 101);
        Item_Stats item_being_generated = Generate_Item_Type(item_level);
        switch (rarity_decider)
        {
            case < 25:
                item_being_generated.rarity = "poor";
                item_being_generated.min_modifier_number = 0;
                item_being_generated.max_modifier_number = 0;
                break;
            case < 50:
                item_being_generated.rarity = "normal";
                item_being_generated.min_modifier_number = 0;
                item_being_generated.max_modifier_number = 2;
                break;
            case < 75:
                item_being_generated.rarity = "Rare";
                item_being_generated.min_modifier_number = 1;
                item_being_generated.max_modifier_number = 4;
                break;
            case < 100:
                item_being_generated.rarity = "Legendary";
                item_being_generated.min_modifier_number = 2;
                item_being_generated.max_modifier_number = 6;
                break;
            default:
                item_being_generated.rarity = "poor";
                item_being_generated.min_modifier_number = 0;
                item_being_generated.max_modifier_number = 0;
                break;
        }

        Generate_Modifiers(item_being_generated, UnityEngine.Random.Range(item_being_generated.min_modifier_number, item_being_generated.max_modifier_number));
        return item_being_generated;
        
        
    }
    public Item_Stats Generate_Item_Type(float item_level)
    {
        int item_type_decider = UnityEngine.Random.Range(1,3);
        if (item_type_decider == 1)
        {
            List<Item_Tag> tags = new List<Item_Tag>();
            List<Item_Modifier> modifiers = new List<Item_Modifier>();
            Weapon_Item_Stats item_being_generated = new Weapon_Item_Stats(item_level, modifiers, tags);
            item_being_generated.tags.Add(Item_Tag.Weapon);
            item_type_decider = UnityEngine.Random.Range(1, 4);
            switch (item_type_decider)
            {
                case 1:
                    item_being_generated.tags.Add(Item_Tag.Melee);
                    item_type_decider = UnityEngine.Random.Range(1, 3);
                    switch (item_type_decider)
                    {
                        case 1:
                            item_being_generated.tags.Add(Item_Tag.One_hand);
                            break;
                        case 2:
                            item_being_generated.tags.Add(Item_Tag.Two_hand);
                            break;
                        default: break;
                    }
                    break;
                case 2:
                    item_being_generated.tags.Add(Item_Tag.Magic);
                    item_type_decider = UnityEngine.Random.Range(1, 3);
                    switch (item_type_decider)
                    {
                        case 1:
                            item_being_generated.tags.Add(Item_Tag.One_hand);
                            break;
                        case 2:
                            item_being_generated.tags.Add(Item_Tag.Two_hand);
                            break;
                        default: break;
                    }
                    break;
                case 3:
                    item_being_generated.tags.Add(Item_Tag.Bow);
                    item_being_generated.tags.Add(Item_Tag.Two_hand);
                    break;
                default: break;
            }
            return item_being_generated;
        }
        else if (item_type_decider == 2)
        {
            List<Item_Tag> tags = new List<Item_Tag>();
            List<Item_Modifier> modifiers = new List<Item_Modifier>();
            Armor_Item_Stats item_being_generated = new Armor_Item_Stats(item_level, modifiers, tags);
            item_being_generated.tags.Add(Item_Tag.Armor);
            item_type_decider = UnityEngine.Random.Range(1, 4);
            switch (item_type_decider)
            {
                case 1:
                    item_being_generated.tags.Add(Item_Tag.Heavy);
                    item_type_decider = UnityEngine.Random.Range(1, 8);
                    switch (item_type_decider)
                    {
                        case 1:
                            item_being_generated.tags.Add(Item_Tag.Head);
                            break;
                        case 2:
                            item_being_generated.tags.Add(Item_Tag.Chest);
                            break;
                        case 3:
                            item_being_generated.tags.Add(Item_Tag.Wrist);
                            break;
                        case 4:
                            item_being_generated.tags.Add(Item_Tag.Hand);
                            break;
                        case 5:
                            item_being_generated.tags.Add(Item_Tag.Waist);
                            break;
                        case 6:
                            item_being_generated.tags.Add(Item_Tag.Leg);
                            break;
                        case 7:
                            item_being_generated.tags.Add(Item_Tag.Feet);
                            break;
                        default: break;
                    }
                    break;
                case 2:
                    item_being_generated.tags.Add(Item_Tag.Medium);
                    item_type_decider = UnityEngine.Random.Range(1, 8);
                    switch (item_type_decider)
                    {
                        case 1:
                            item_being_generated.tags.Add(Item_Tag.Head);
                            break;
                        case 2:
                            item_being_generated.tags.Add(Item_Tag.Chest);
                            break;
                        case 3:
                            item_being_generated.tags.Add(Item_Tag.Wrist);
                            break;
                        case 4:
                            item_being_generated.tags.Add(Item_Tag.Hand);
                            break;
                        case 5:
                            item_being_generated.tags.Add(Item_Tag.Waist);
                            break;
                        case 6:
                            item_being_generated.tags.Add(Item_Tag.Leg);
                            break;
                        case 7:
                            item_being_generated.tags.Add(Item_Tag.Feet);
                            break;
                        default: break;
                    }
                    break;
                case 3:
                    item_being_generated.tags.Add(Item_Tag.Light);
                    item_type_decider = UnityEngine.Random.Range(1, 8);
                    switch (item_type_decider)
                    {
                        case 1:
                            item_being_generated.tags.Add(Item_Tag.Head);
                            break;
                        case 2:
                            item_being_generated.tags.Add(Item_Tag.Chest);
                            break;
                        case 3:
                            item_being_generated.tags.Add(Item_Tag.Wrist);
                            break;
                        case 4:
                            item_being_generated.tags.Add(Item_Tag.Hand);
                            break;
                        case 5:
                            item_being_generated.tags.Add(Item_Tag.Waist);
                            break;
                        case 6:
                            item_being_generated.tags.Add(Item_Tag.Leg);
                            break;
                        case 7:
                            item_being_generated.tags.Add(Item_Tag.Feet);
                            break;
                        default: break;
                    }
                    break;
                default: break;
            }
            return item_being_generated;
        } 
        else return null;
    }
    public Item_Stats Generate_Modifiers(Item_Stats item_being_generated, int modifier_number)
    {
        Debug.Log(item_being_generated.tags.ToString());
        List<Item_Modifiers_Scriptable_Object> modifiers_that_fit = new List<Item_Modifiers_Scriptable_Object>();
        foreach (Item_Modifiers_Scriptable_Object modifier in Loot_Manager.Instance.modifiers)
        {
            int modifier_tag_matches = 0;
            foreach (Item_Tag tag in item_being_generated.tags)
            {
                foreach (Item_Tag modifier_tag in modifier.tags)
                {
                    if (modifier_tag == tag)
                    {
                        modifier_tag_matches++;
                    }
                }
                if (modifier_tag_matches == item_being_generated.tags.Count)
                {
                    modifiers_that_fit.Add(modifier);
                }
            }
        }
        if (modifiers_that_fit != null || modifiers_that_fit.Count >= 0) 
        {
            for (int i = 0; i < modifier_number; i++)
            {
                int modifier_chooser = UnityEngine.Random.Range(0, modifiers_that_fit.Count);
                if (modifier_chooser >= 0 && modifier_chooser <= modifiers_that_fit.Count - 1)
                {
                    Item_Modifiers_Scriptable_Object modifier = modifiers_that_fit[modifier_chooser];
                    float modifier_rank = item_being_generated.level;
                    float value = UnityEngine.Random.Range(modifier.min_value * modifier_rank, modifier.max_value * modifier_rank);
                    Item_Modifier current_modifier = new Item_Modifier(modifier_rank, modifier.tags, modifier.name, value, modifier.max_value * modifier_rank, modifier.min_value * modifier_rank); ;
                    item_being_generated.modifiers.Add(current_modifier);
                }
                else continue;
            }
        }
        
        return item_being_generated;
    }
}
