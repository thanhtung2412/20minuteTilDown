using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormal : Enemy
{
    public override void Die()
    {
        base.Die();        
        ChangeAnim("EnemyNormalDie");       
    }
    protected override void MoveToTarget()
    {
        base.MoveToTarget();
        if (isMove)
        {
            ChangeAnim("EnemyNormalWalk");
        }
    }
    public override void EffectDie()
    {
        base.EffectDie();
        //Debug.Log("dssdas");
        SimplePool.Despawn(this);
    }
}
