using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.character.transform.position = transform.position;
    }
}
