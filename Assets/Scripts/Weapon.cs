using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet_prefab;
    public Transform fire_point;
    public float fire_force = 40f;

    public void Fire()
    {
        GameObject bullet = Instantiate(bullet_prefab, fire_point.position, fire_point.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(fire_point.up * fire_force, ForceMode2D.Impulse);
    }
}
