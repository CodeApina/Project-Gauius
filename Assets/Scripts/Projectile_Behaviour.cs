using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Behaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy_Behaviour>(out Enemy_Behaviour enemy))
        {
            if (enemy.alive == true)
            {
                int damage = GameManager.Instance.player_damage.Damage_Calculation();
                enemy.Enemy_Takes_Damage(damage);
            }
        }
        Destroy(gameObject);
    }
}
