using Character;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(fileName = "Movement_Skill_Scriptable_Object", menuName = "Scriptable_objects/Movement Skill")]
public class Movement_Scriptable_Object : Skills_Scriptable_Object
{
    public float velocity;
    private Character_Controller controller;
    public override void Innitialize(GameObject parent)
    {
        if (GameManager.Instance.character_alive)
        {
            controller = parent.GetComponent<Character_Controller>();
            
        }
        
    }
    public override void Trigger_Skill()
    {
        controller.Movement_Ability(velocity);
    }
}
