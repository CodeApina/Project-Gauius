using UnityEngine;

[CreateAssetMenu(fileName = "Skills_Scriptable_Object", menuName = "Scriptable_objects/Skill")]
public class Skills_Scriptable_Object : ScriptableObject
{
    public float base_mana_cost;
    public float base_cooldown;
    public float base_duration;

    public virtual void Activate(GameObject parent)
    {

    }
}
