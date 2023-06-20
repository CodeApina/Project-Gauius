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
        Rarity_Weights poor = new Rarity_Weights("poor", 1);
        Rarity_Weights normal = new Rarity_Weights("normal", 1);
        Rarity_Weights rare = new Rarity_Weights("rare", 1);
        Rarity_Weights legendary = new Rarity_Weights("legendary", 1);
        Rarity_Weights[] weights =
        {
            poor, normal, rare, legendary
        };

        switch (monster_level)
        {
            case <= 25:
                poor.rarity_weight = 50;
                normal.rarity_weight = 25;
                rare.rarity_weight = 10;
                legendary.rarity_weight = 2;
                item_being_generated.rarity = Weighted_Rarity(weights).rarity;
                break;
            case <= 50:
                poor.rarity_weight = 50;
                normal.rarity_weight = 25;
                rare.rarity_weight = 10;
                legendary.rarity_weight = 2;
                item_being_generated.rarity = Weighted_Rarity(weights).rarity;
                break;
            case <= 75:
                poor.rarity_weight = 50;
                normal.rarity_weight = 25;
                rare.rarity_weight = 10;
                item_being_generated.rarity = Weighted_Rarity(weights).rarity;
                break;
            case <= 100:
                poor.rarity_weight = 50;
                normal.rarity_weight = 25;
                rare.rarity_weight = 10;
                legendary.rarity_weight = 2;
                item_being_generated.rarity = Weighted_Rarity(weights).rarity;
                break;
            default:
                Debug.Log("Error rarity asignment failed");
                break;
        }

        Generate_Modifiers(item_being_generated, UnityEngine.Random.Range(item_being_generated.min_modifier_number, item_being_generated.max_modifier_number));
        return item_being_generated;
        
        
    }
    private Rarity_Weights Weighted_Rarity(Rarity_Weights[] weights)
    {
        int total_weight = 0;
        foreach (Rarity_Weights w in weights)
        {
            total_weight += w.rarity_weight;
        }
        int random = UnityEngine.Random.Range(0, total_weight);
        int total = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            total += weights[i].rarity_weight;
            if (total > random)
            {
                return weights[i];
            }
            else
            {
                continue;
            }
        }
        Debug.Log("Error Weighted_Rarity failed to roll rarity");
        return Weighted_Rarity(weights);
    }
    private struct Rarity_Weights
    {
        string rarity_string;
        int rarity_weight_int;
        public string rarity
        {
            get { return rarity_string; }
            set { rarity_string = value; }
        }
        public int rarity_weight
        {
            get { return rarity_weight_int; }
            set { rarity_weight_int = value; }
        }

        public Rarity_Weights(string rarity, int rarity_weight)
        {
            rarity_string = rarity;
            rarity_weight_int = rarity_weight;
        }
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
        switch (item_being_generated.rarity)
        {
            case "poor":
                item_being_generated.min_modifier_number = 0;
                item_being_generated.max_modifier_number = 0;
                break;
            case "normal":
                item_being_generated.min_modifier_number = 1;
                item_being_generated.max_modifier_number = 2;
                break;
            case "rare":
                item_being_generated.min_modifier_number = 2;
                item_being_generated.max_modifier_number = 4;
                break;
            case "legendary":
                item_being_generated.min_modifier_number = 4;
                item_being_generated.max_modifier_number = 6;
                break;
        }
        Debug.Log(item_being_generated.tags.ToString());
        List<Item_Modifiers_Scriptable_Object> modifiers_that_fit = new List<Item_Modifiers_Scriptable_Object>();
        foreach (Item_Modifiers_Scriptable_Object modifier in Loot_Manager.Instance.modifiers)
        {
            bool tag_missmatch = true;
            foreach (Item_Tag tag in modifier.tags)
            {
                if (item_being_generated.tags.Contains(tag))
                {
                    tag_missmatch = false;
                }
            }
            if (!tag_missmatch)
            {
                modifiers_that_fit.Add(modifier);
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
                    Item_Modifier current_modifier = new Item_Modifier(modifier_rank, modifier.tags, modifier.affected_atribute, modifier.name, value, modifier.max_value * modifier_rank, modifier.min_value * modifier_rank); ;
                    item_being_generated.modifiers.Add(current_modifier);
                    modifiers_that_fit.Remove(modifier);
                }
                else continue;
            }
        }
        
        return item_being_generated;
    }
}
