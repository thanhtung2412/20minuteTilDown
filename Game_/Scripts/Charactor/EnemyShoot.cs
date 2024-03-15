using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : Enemy
{        
    
    [SerializeField] private float distanceToStop = 3f;

    [SerializeField] private float fireRate;
    [SerializeField] private float timeToFire;

    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject bulletEnemyPb;
  
    public override void Update()
    {
        base.Update();
        if (target != null && Vector2.Distance(target.position, transform.position) <= distanceToStop)
        {
            Shoot();
        }
    }
    public override void Die()
    {
        base.Die();
        ChangeAnim("EnemyShootDie");       
    }
    protected override void MoveToTarget()
    {
        base.MoveToTarget();
        if (isMove)
        {
            ChangeAnim("EnemyShootWalk");
        }
    }
    public override void EffectDie()
    {
        base.EffectDie();
        SimplePool.Despawn(this);
    }
    private void Shoot()
    {
        if (timeToFire <= 0f)
        {
            timeToFire = fireRate;
            Vector2 lookDir = target.transform.position - transform.position;
           
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            firingPoint.transform.rotation = rotation;

            if (firingPoint.transform.eulerAngles.z > 90 && firingPoint.transform.eulerAngles.z < 270)
            {
                firingPoint.transform.localScale = new Vector3(1, -1, 0);
            }
            else
            {
                firingPoint.transform.localScale = new Vector3(1, 1, 0);
            }
            //Instantiate(bulletEnemyPb, firingPoint.position, firingPoint.rotation);
            SimplePool.Spawn<BulletEnemy>(PoolType.BulletEnemy, firingPoint.position, firingPoint.rotation);
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }
    public override void FixedUpdate()
    {
        base .FixedUpdate();
        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
            {
                Vector2 targetDir = target.position - transform.position;
                rb.velocity = targetDir.normalized * speedBot;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
   
  
}
