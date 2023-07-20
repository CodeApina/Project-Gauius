using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fire_point;

    public void Fire(GameObject bullet_prefab, float fire_force = 40f)
    {
        GameObject bullet = Instantiate(bullet_prefab, fire_point.position, fire_point.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(fire_point.up * fire_force, ForceMode2D.Impulse);
    }
}
