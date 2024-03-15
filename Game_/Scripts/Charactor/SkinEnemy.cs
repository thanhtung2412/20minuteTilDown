using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinEnemy : MonoBehaviour
{
    private Enemy enemy;
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }   
    public void LateDie()
    {        
        enemy.EffectDie();
    }
}
