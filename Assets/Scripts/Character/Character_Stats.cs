using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Stats : MonoBehaviour
{
    public static Character_Stats Instance;
    public float projectile_pierce;
    public float projectile_chain = 2;

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
}
