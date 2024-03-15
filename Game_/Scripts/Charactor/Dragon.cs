using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] private float rangeShoot = 6f;
    [SerializeField] private GameObject pointShoot;
    [SerializeField] private Transform[] point;
    [SerializeField] private float timeToFire = -1;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private GameObject bulletDragon;
    private float timeDeath = 60f;


    private void Start()
    {
        Destroy(gameObject, timeDeath);
    }
    private void Update()
    {
        CheckEnemy();
    }
    private void CheckEnemy()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, rangeShoot);

        for (int i = 0; i < collider.Length; i++)
        {
            if (collider[i].TryGetComponent<Enemy>(out Enemy enemy))
            {
                Vector2 lookDir = enemy.transform.position - transform.position;               
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                pointShoot.transform.rotation = rotation;              
                PlayerShoot();
            }
        }
    }
    private void PlayerShoot()
    {
        if (timeToFire <= 0)
        {
            for (int i = 0; i < point.Length; i++)
            {                       
                SimplePool.Spawn<BulletDragon>(PoolType.BulletDragon, point[i].position, point[i].rotation);
                timeToFire = fireRate;
            }
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }
}
