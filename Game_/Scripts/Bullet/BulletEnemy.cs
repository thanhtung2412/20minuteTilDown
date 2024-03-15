using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
                player.TakeDameEffect(damage);
                UIGamePlay.heathBar.UpdateHpBar(player.health);
            }
            SimplePool.Despawn(this);      
        }
    }
}
