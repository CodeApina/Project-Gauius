using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Behaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
