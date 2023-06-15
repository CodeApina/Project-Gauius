using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float move_speed = 5f;
    private Vector2 target;
    private Vector2 aim_target;
    public Rigidbody2D rb;
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }
    private void OnEnable()
    {
        Player_Behaviour.On_Player_Death += Handle_RB_On_Player_Death;
    }
    private void OnDisable()
    {
        Player_Behaviour.On_Player_Death -= Handle_RB_On_Player_Death;
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.player_alive == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            transform.position = Vector2.MoveTowards(transform.position, target, move_speed * Time.deltaTime);
            if (Input.GetMouseButtonDown(1))
            {
                aim_target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                weapon.Fire();
            }
        }
        
    }
    private void FixedUpdate()
    {
        Vector2 aim_direction = aim_target;
        float aim_angle = Mathf.Atan2(aim_direction.y, aim_direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aim_angle;
    }

    void Handle_RB_On_Player_Death(Player_Behaviour player)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
