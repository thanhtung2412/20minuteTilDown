using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float speedFall = 5f;
    public Vector3 PointFall;
    [SerializeField] private int dameExplode;
    [SerializeField] private float rangeExplode;
    [SerializeField] private ExplodeEff explodeEff;
    void Update()
    {
        MeteorFalling();
    }
    private void MeteorFalling()
    {
        transform.position = Vector3.MoveTowards(transform.position, PointFall, speedFall * Time.deltaTime);
        if(Vector3.Distance(transform.position, PointFall) <= 0.1f)
        {
            Instantiate(explodeEff, transform.position, Quaternion.identity);
            Explode();
            Destroy(gameObject);
        }
    }
    private void Explode()
    {      
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, rangeExplode);

        for (int i = 0; i < collider.Length; i++)
        {
            Enemy enemy = collider[i].gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(dameExplode);
                enemy.TakeDameEffect(dameExplode);
            }

        }
    }
}
