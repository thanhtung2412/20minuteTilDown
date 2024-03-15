using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : Enemy
{
    public float rangeExplode = 2f;
    [SerializeField] private int dameExplode = 12;
    
    
    public override void Die()
    {
        base.Die();
        ChangeAnim("EnemyBombDie");              
    }
    protected override void MoveToTarget()
    {
        base.MoveToTarget();
        if (isMove)
        {
            ChangeAnim("EnemyBombWalk");
        }
    }
    public override void EffectDie()
    {
        base.EffectDie();
        Explode();
        SimplePool.Despawn(this);
    }
    private void Explode()
    {
        Collider2D mycol = GetComponent<Collider2D>();
        if(mycol != null )
        {
            mycol.enabled = false;
        }
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, rangeExplode);

        for (int i = 0; i < collider.Length; i++)
        {           
            Charactor newChar = collider[i].gameObject.GetComponent<Charactor>();
            if(newChar != null)
            {
                newChar.TakeDamage(dameExplode);
                newChar.TakeDameEffect(dameExplode);             
            }
          
        }
    }
}