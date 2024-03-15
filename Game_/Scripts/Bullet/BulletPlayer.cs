using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {          
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {             
                enemy.TakeDamage(damage);
                enemy.TakeDameEffect(damage);
            }
            SimplePool.Despawn(this);
        }
    }
}