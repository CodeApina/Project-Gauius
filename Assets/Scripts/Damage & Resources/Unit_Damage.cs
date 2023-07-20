using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Damage
{
    float current_damage_min;
    float current_damage_max;
    float current_crit_multiplier;
    float current_crit_chance;

    public float damage_min
    {
        get { return current_damage_min; }
        set { current_damage_min = value; }
    }
    public float damage_max
    {
        get { return current_damage_max; }
        set { current_damage_max = value; }
    }
    public float crit_multiplier
    {
        get { return current_crit_multiplier; }
        set { current_crit_multiplier = value;}
    }
    public float crit_chance
    {
        get { return current_crit_chance; }
        set { current_crit_chance = value; }
    }
    public Unit_Damage(float damage_min, float damage_max , float crit_multiplier, float crit_chance)
    {
        current_damage_min = damage_min;
        current_damage_max = damage_max;
        current_crit_multiplier= crit_multiplier;
        current_crit_chance = crit_chance;   
    }
    public int Damage_Calculation()
    {
        float hit_damage = UnityEngine.Random.Range(current_damage_min, current_damage_max + 1);
        if (crit_chance >= UnityEngine.Random.Range(1, 101))
        {
            float float_damage = hit_damage;
            return Convert.ToInt32(Mathf.Round(float_damage * current_crit_multiplier));
        }
        else
        {
            return Convert.ToInt32(hit_damage);
        }
    }
}
