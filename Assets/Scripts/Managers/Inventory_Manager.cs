using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour
{
    public static Inventory_Manager Instance;

    public List<GameObject> inventory;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }
}
