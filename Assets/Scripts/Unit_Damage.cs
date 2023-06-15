using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Damage
{
    int current_damage;
    float current_crit_multiplier;
    int current_crit_chance;

    public int damage
    {
        get { return current_damage; }
        set { current_damage = value; }
    }
    public float crit_multiplier
    {
        get { return current_crit_multiplier; }
        set { current_crit_multiplier = value;}
    }
    public int crit_chance
    {
        get { return current_crit_chance; }
        set { current_crit_chance = value; }
    }
    public Unit_Damage(int damage, float crit_multiplier, int crit_chance)
    {
        current_damage = damage;
        current_crit_multiplier= crit_multiplier;
        current_crit_chance = crit_chance;   
    }
    public int Damage_Calculation()
    {
        if (crit_chance >= UnityEngine.Random.Range(1, 100))
        {
            float float_damage = current_damage;
            return Convert.ToInt32(Mathf.Round(float_damage * current_crit_multiplier));
        }
        else
        {
            return current_damage;
        }
    }
}
