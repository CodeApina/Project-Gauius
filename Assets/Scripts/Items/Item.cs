using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.CodeDom.Compiler;
using Unity.VisualScripting;
using System.Linq;

public class Item
{
    Weighted_Rolls rolls = new Weighted_Rolls();
    public Item_Stats Generate_Item(float monster_level)
    {
        float item_level = monster_level;
        Item_Stats item_being_generated = Generate_Item_Type(item_level);
        Weighted_Rolls.String_Weights poor = new Weighted_Rolls.String_Weights("poor", 1);
        Weighted_Rolls.String_Weights normal = new Weighted_Rolls.String_Weights("normal", 1);
        Weighted_Rolls.String_Weights rare = new Weighted_Rolls.String_Weights("rare", 1);
        Weighted_Rolls.String_Weights legendary = new Weighted_Rolls.String_Weights("legendary", 1);
        
        Weighted_Rolls.String_Weights[] weights =
        {
            poor, normal, rare, legendary
        };

        switch (monster_level)
        {
            case <= 25:
                poor.weight = 50;
                normal.weight = 25;
                rare.weight = 10;
                legendary.weight = 2;
                item_being_generated.rarity = rolls.Weighted_String(weights).string_;
                break;
            case <= 50:
                poor.weight = 50;
                normal.weight = 25;
                rare.weight = 10;
                legendary.weight = 2;
                item_being_generated.rarity = rolls.Weighted_String(weights).string_;
                break;
            case <= 75:
                poor.weight = 50;
                normal.weight = 25;
                rare.weight = 10;
                item_being_generated.rarity = rolls.Weighted_String(weights).string_;
                break;
            case <= 100:
                poor.weight = 50;
                normal.weight = 25;
                rare.weight = 10;
                legendary.weight = 2;
                item_being_generated.rarity = rolls.Weighted_String(weights).string_;
                break;
            default:
                Debug.Log("Error rarity asignment failed");
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
            Item_Model_Chooser(item_being_generated);
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
            Item_Model_Chooser(item_being_generated);
            return item_being_generated;
        } 
        else return null;
    }
    public Item_Stats Item_Model_Chooser(Item_Stats item_being_generated)
    {
        if (item_being_generated.tags.Contains(Item_Tag.Weapon))
        {
            List<Weapon_Scriptable_Object> models_that_fit = new List<Weapon_Scriptable_Object>();
            foreach (var model in Loot_Manager.Instance.weapon_models)
            {
                bool tag_missmatch = true;
                foreach (Item_Tag tag in model.tags)
                {
                    if (item_being_generated.tags.Contains(tag))
                    {
                        tag_missmatch = false;
                    }
                }
                if (!tag_missmatch)
                {
                    models_that_fit.Add(model);
                }
                item_being_generated.model = models_that_fit[UnityEngine.Random.Range(0, models_that_fit.Count - 1)];
            }
        }
        else if (item_being_generated.tags.Contains(Item_Tag.Armor))
        {
            List<Armor_Scriptable_Object> models_that_fit = new List<Armor_Scriptable_Object>();
            foreach (var model in Loot_Manager.Instance.armor_models)
            {
                bool tag_missmatch = true;
                foreach (Item_Tag tag in model.tags)
                {
                    if (item_being_generated.tags.Contains(tag))
                    {
                        tag_missmatch = false;
                    }
                }
                if (!tag_missmatch)
                {
                    models_that_fit.Add(model);
                }
                item_being_generated.model = models_that_fit[UnityEngine.Random.Range(0, models_that_fit.Count - 1)];
            }
        }
        
        return item_being_generated;
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
                    int modifier_rank;
                    Item_Modifiers_Scriptable_Object modifier = modifiers_that_fit[modifier_chooser];
                    Weighted_Rolls.Int_Weights rank_one = new Weighted_Rolls.Int_Weights(1, 1);
                    Weighted_Rolls.Int_Weights rank_two = new Weighted_Rolls.Int_Weights(2, 1);
                    Weighted_Rolls.Int_Weights rank_three = new Weighted_Rolls.Int_Weights(3, 1);
                    Weighted_Rolls.Int_Weights rank_four = new Weighted_Rolls.Int_Weights(4, 1);
                    Weighted_Rolls.Int_Weights rank_five = new Weighted_Rolls.Int_Weights(5, 1);
                    Weighted_Rolls.Int_Weights[] weights =
                    {
                        rank_one,rank_two,rank_three,rank_four,rank_five
                    };
                    switch (item_being_generated.level)
                    {
                        case <= 25:
                            rank_one.weight = 50;
                            rank_two.weight = 25;
                            rank_three.weight = 10;
                            rank_four.weight = 5;
                            rank_five.weight = 1;
                            modifier_rank = rolls.Weighted_Int(weights).int_;
                            break;
                        case <= 50:
                            rank_one.weight = 20;
                            rank_two.weight = 55;
                            rank_three.weight = 20;
                            rank_four.weight = 10;
                            rank_five.weight = 4;
                            modifier_rank = rolls.Weighted_Int(weights).int_;
                            break;
                        case <= 75:
                            rank_one.weight = 10;
                            rank_two.weight = 30;
                            rank_three.weight = 50;
                            rank_four.weight = 25;
                            rank_five.weight = 10;
                            modifier_rank = rolls.Weighted_Int(weights).int_;
                            break;
                        case <= 100:
                            rank_one.weight = 5;
                            rank_two.weight = 15;
                            rank_three.weight = 30;
                            rank_four.weight = 50;
                            rank_five.weight = 25;
                            modifier_rank = rolls.Weighted_Int(weights).int_;
                            break;
                        default:
                            modifier_rank = 0;
                            Debug.Log("Error rarity asignment failed");
                            break;
                    }
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
