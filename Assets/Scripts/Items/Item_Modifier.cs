using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Modifier
{
    string modifier_name;
    List<Item_Tag> modifier_tags;
    float modifier_value;
    float modifier_max_value;
    float modifier_min_value;
    float modifier_rank;
    public string name
    {
        get { return modifier_name; }
        set { modifier_name = value; }
    }
    public List<Item_Tag> tags
    {
        get { return modifier_tags; }
        set { modifier_tags = value; }
    }
    public float value
    {
        get { return modifier_value; }
        set { modifier_value = value; }
    }
    float max_value
    {
        get { return modifier_max_value; }
        set { modifier_max_value = value; }
    }
    float min_value
    {
        get { return modifier_min_value; }
        set { modifier_min_value = value; }
    }
    public float rank
    {
        get { return modifier_rank; }
        set { modifier_rank = value; }
    }

    public Item_Modifier(float rank, List<Item_Tag> tags, string name = "default", float value = 9911991199, float max_value = 9922992299, float min_value = 9900990099)
    {
        modifier_name = name;
        modifier_value = value;
        modifier_max_value = max_value;
        modifier_min_value = min_value;
        modifier_rank = rank;
        modifier_tags = tags;
    }
}
