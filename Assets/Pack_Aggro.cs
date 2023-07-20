using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pack_Aggro : MonoBehaviour
{
    protected bool agroed = false;

    private void Child_Agro()
    {
        
        BroadcastMessage("Agro");
        
        
    }
}
