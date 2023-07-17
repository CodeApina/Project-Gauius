using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pack_Aggro : MonoBehaviour
{
    protected bool agroed = false;

    private void Update()
    {
        foreach(Transform child in transform)
        {
            if (child.GetComponent<Enemy_Behaviour>().agroed == true)
            {
                agroed = true;
            }
            
        }
        if (agroed == true)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Enemy_Behaviour>().agroed = true;
            }
        }
        
        
    }
}
