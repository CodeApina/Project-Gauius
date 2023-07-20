using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controls : MonoBehaviour
{
    public Transform player_transform;
    public Vector3 offset;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.character;
        player_transform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameManager.Instance.character;
        }
        if (player_transform == null)
        {
            player_transform = player.GetComponent<Transform>();
        }
         base.transform.position = new Vector3(player_transform.position.x + offset.x, player_transform.position.y + offset.y, offset.z);
    }
}
