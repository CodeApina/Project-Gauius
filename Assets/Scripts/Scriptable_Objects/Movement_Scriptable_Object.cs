using Character;
using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Movement_Skill_Scriptable_Object", menuName = "Scriptable_objects/Movement Skill")]
public class Movement_Scriptable_Object : Skills_Scriptable_Object
{
    public float velocity;
    private Character_Controller controller;
    private Skill_Cooldown button;
    public override void Innitialize(GameObject parent)
    {
        if (GameManager.Instance.character_alive)
        {
            controller = parent.GetComponent<Character_Controller>();
            button = parent.GetComponent<Skill_Cooldown>();
        }
        
    }
    public override void Trigger_Skill()
    {
        controller.Movement_Ability(velocity, skill_range, button.move_to_range);
    }
}
