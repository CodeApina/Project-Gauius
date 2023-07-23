using Enemy;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game_Object_Activator : MonoBehaviour
{
    public CircleCollider2D trigger_collider;
    // Start is called before the first frame update
    void Start()
    {
        List<Collider2D> colliders_hit = new List<Collider2D>();
        colliders_hit.Add(Physics2D.OverlapCircle(transform.position, trigger_collider.radius, layerMask:8));
        foreach (Collider2D collider in colliders_hit)
        {
            Set_GameObject_Status(collider, true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Set_GameObject_Status(other, true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Set_GameObject_Status(other, false);
    }

    public void Set_GameObject_Status(Collider2D collider, bool state)
    {
        if (collider != null)
        {
            if (collider.TryGetComponent<Enemy_Behaviour>(out Enemy_Behaviour behaviour))
            {
                collider.GetComponentInChildren<MonoBehaviour>().enabled = state;
                collider.GetComponent<MonoBehaviour>().enabled = state;
            }
            if (collider.TryGetComponent<Item>(out Item item))
            {
                collider.GetComponentInChildren<MonoBehaviour>().enabled = state;
                collider.GetComponent<MonoBehaviour>().enabled= state;
            }
        }
        
        
    }


}
