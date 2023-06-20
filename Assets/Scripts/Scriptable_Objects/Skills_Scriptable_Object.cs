using UnityEngine;
using UnityEngine.UI;

public  abstract class Skills_Scriptable_Object : ScriptableObject
{
    public string skill_name;
    public string skill_description;
    public Sprite skill_sprite;
    public AudioClip skill_audio;
    public float base_mana_cost;
    public float base_cooldown;
    public float base_duration;
    public float level_multiplier;

    public abstract void Innitialize(GameObject parent);
    public abstract void Trigger_Skill();
}
