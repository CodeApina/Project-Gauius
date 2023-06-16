using Character;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills_Scriptable_Object", menuName = "Scriptable_objects/Movement Skill")]
public class Movement_Scriptable_Object : Skills_Scriptable_Object
{
   public float velocity;

   public override void Activate(GameObject parent)
    {
        if (GameManager.Instance.player_alive)
        {
            Character_Controller controller = parent.GetComponent<Character_Controller>();
            controller.Movement_Ability(velocity);
        }
        
    }
}
