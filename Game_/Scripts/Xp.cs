using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : GameUnit
{
    private int xpAmount = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIGamePlay.levelBar.UpdateLevelBar(xpAmount);
            SimplePool.Despawn(this);
        }
    }
}
