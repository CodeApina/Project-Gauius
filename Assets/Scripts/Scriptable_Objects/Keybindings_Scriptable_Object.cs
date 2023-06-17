using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "Scriptable_objects/Keybindings")]
public class Keybindings_Scriptable_Object : ScriptableObject
{
    [System.Serializable]
    public class Keybinding_Check
    {
        public Keybinding_Actions keybinding_actions;
        public KeyCode key_code;
    }
    public Keybinding_Check[] keybinding_checks;
}
