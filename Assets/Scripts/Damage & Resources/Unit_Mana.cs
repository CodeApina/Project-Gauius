using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Mana
{
    float current_mana;
    float current_max_mana;
    float current_mana_regen;

    public float mana
    {
        get { return current_mana; }
        set { current_mana = value; }
    }
    public float max_mana
    {
        get { return current_max_mana; }
        set { current_max_mana = value; }
    }
    public float mana_regen
    {
        get { return current_mana_regen; }
        set { current_mana_regen = value; }
    }
    public Unit_Mana(float mana, float max_mana, float mana_regen)
    {
        current_mana = mana;
        current_max_mana = max_mana;
        current_mana_regen = mana_regen;
    }

    public void Using_Mana (float mana_used)
    {
        current_mana -= mana_used;
    }
    public void Mana_Regen(float regen)
    {
        if (current_mana < current_max_mana)
        {
            current_mana += regen;
        }
        if (current_mana > current_max_mana)
        {
            current_mana = current_max_mana;
        }
    }
}
