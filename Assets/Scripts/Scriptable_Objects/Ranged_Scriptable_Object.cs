using Character;
using UnityEngine;

[CreateAssetMenu(fileName = "Ranged_Skill_Scriptable_Object", menuName = "Scriptable_objects/Ranged Skill")]
public class Ranged_Scriptable_Object : Skills_Scriptable_Object
{
    public float min_base_damage;
    public float max_base_damage;
    public float base_crit_chance;
    public float base_crit_multiplier;
    public float base_attack_speed;
    public string damage_type;
    public float fire_force = 40f;
    public GameObject projectile_prefab;
    private Character_Controller controller;

    public override void Innitialize(GameObject parent)
    {
        GameManager game_manager = GameManager.Instance;
        if (game_manager.character_alive)
        {
            controller = parent.GetComponent<Character_Controller>();
            controller.fire_force = fire_force;
            controller.projectile_prefab = projectile_prefab;
            controller.attack_speed = base_attack_speed;
            game_manager.character_damage.damage_min = min_base_damage;
            game_manager.character_damage.damage_max = max_base_damage;
            game_manager.character_damage.crit_chance = base_crit_chance;
            game_manager.character_damage.crit_multiplier = base_crit_multiplier;
            
        }
    }
    public override void Trigger_Skill(Skills_Scriptable_Object skill)
    {
        if (GameManager.Instance.character_mana.mana >= base_mana_cost) 
        {
            GameManager.Instance.character_mana.Using_Mana(base_mana_cost);
            controller.weapon.Fire(projectile_prefab, fire_force);
        }
        
    }
}
