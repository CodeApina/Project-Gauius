using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Stats
{
    protected string item_name;
    protected int item_modifier_number;
    protected int item_min_modifier_number;
    protected int item_max_modifier_number;
    protected float item_level_required;
    protected float item_level;
    protected List<Item_Modifier> item_modifiers;
    protected List<Item_Tag> item_tags;
    protected string item_rarity;
    protected string item_type;

    public string name
    {
        get { return item_name; }
        set { item_name = value; }
    }
    public int modifier_number
    {
        get { return item_modifier_number; }
        set { item_modifier_number = value; }
    }
    public int min_modifier_number
    {
        get { return item_min_modifier_number; }
        set { item_min_modifier_number = value; }
    }
    public int max_modifier_number
    {
        get { return item_max_modifier_number; }
        set { item_max_modifier_number = value; }
    }
    public float level_required
    {
        get { return item_level_required; }
        set { item_level_required = value; }
    }
    public float level
    {
        get { return item_level; }
        set { item_level = value; }
    }
    public string rarity
    {
        get { return item_rarity; }
        set { item_rarity = value; }
    }
    public List<Item_Tag> tags
    {
        get { return item_tags; }
        set { item_tags = value; }
    }
    public string type
    {
        get { return item_type; }
        set { item_type = value; }
    }
    public List<Item_Modifier> modifiers
    {
        get { return item_modifiers; }
        set { item_modifiers = value; }
    }
}
