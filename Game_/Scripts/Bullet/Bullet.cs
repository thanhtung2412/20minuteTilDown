using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : GameUnit
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;
    public int damage;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("OnDesPawn", lifeTime);
      
    }
    private void OnDesPawn()
    {
        SimplePool.Despawn(this);
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }
}
