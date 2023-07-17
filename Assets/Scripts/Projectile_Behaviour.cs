using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using UI;

public class Projectile_Behaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy_Behaviour>(out Enemy_Behaviour enemy))
        {
            if (enemy.alive == true)
            {
                int damage = GameManager.Instance.character_damage.Damage_Calculation();
                enemy.Enemy_Takes_Damage(damage, collision.gameObject);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
