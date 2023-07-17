using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Behaviour : MonoBehaviour
{
    public GameObject[] walls; // 0 = north, 1 = south, 2 = east, 3 = west
    public GameObject[] doors;

    public bool[] test_status;
    // Start is called before the first frame update
    void Start()
    {
        UpdateRoom(test_status);
    }

    // Update is called once per frame
    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++) 
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }
    }
}
