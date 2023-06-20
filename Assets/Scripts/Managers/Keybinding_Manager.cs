using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keybinding_Manager : MonoBehaviour
{
    public static Keybinding_Manager Instance {get; private set;}

    [SerializeField] private Keybindings_Scriptable_Object keybindings_scriptable_object ;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }
    public KeyCode Get_Key_For_Skill(Keybinding_Actions keybinding_actions)
    {
        foreach(Keybindings_Scriptable_Object.Keybinding_Check keybinding_check in keybindings_scriptable_object.keybinding_checks)
        {
            if (keybinding_check.keybinding_actions == keybinding_actions)
            {
                return keybinding_check.key_code;
            }
        }
        return KeyCode.None;
    }
    public bool Get_Key_Down(Keybinding_Actions key)
    {
        foreach(Keybindings_Scriptable_Object.Keybinding_Check keybinding_check in keybindings_scriptable_object.keybinding_checks)
        {
            if (keybinding_check.keybinding_actions == key)
                return Input.GetKeyDown(keybinding_check.key_code);
        }
        return false;
    }
    public bool Get_Key_Up(Keybinding_Actions key)
    {
        foreach (Keybindings_Scriptable_Object.Keybinding_Check keybinding_check in keybindings_scriptable_object.keybinding_checks)
        {
            if (keybinding_check.keybinding_actions == key)
                return Input.GetKeyDown(keybinding_check.key_code);
        }
        return false;
    }
    public bool Get_Key(Keybinding_Actions key)
    {
        foreach (Keybindings_Scriptable_Object.Keybinding_Check keybinding_check in keybindings_scriptable_object.keybinding_checks)
        {
            if (keybinding_check.keybinding_actions == key)
                return Input.GetKeyDown(keybinding_check.key_code);
        }
        return false;
    }
}
