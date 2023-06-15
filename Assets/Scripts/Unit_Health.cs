using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Health
{
    float current_health;
    float current_max_health;
    float current_regen;

    public float health
    {
        get { return current_health; }
        set { current_health = value; }
    }
    public float max_health
    {
        get { return current_max_health; }
        set { current_max_health = value; }
    }
    public float regen
    {
        get { return current_regen; }
        set { current_regen = value; }
    }

    public Unit_Health(float health, float max_health, float regen)
    {
        current_health=health;
        current_max_health=max_health;
        current_regen=regen;
    }

    public void Damage_Unit(int damage)
    {
        if(current_health > 0)
        {
            current_health -= damage;
        }
        if(current_health <= 0)
        {
            current_health = 0;
        }
    }
    public void Heal_Unit(float heal_amount)
    {
        if(current_health < current_max_health)
        {
            current_health += heal_amount;
        }
        if (current_health > current_max_health)
        {
            current_health = current_max_health;
        }
    }
    public void Health_Regen(float regen)
    {
        if(current_health < current_max_health)
        {
            current_health += regen;
        }
        if(current_health > current_max_health)
        {
            current_health = current_max_health;
        }
    }
}
