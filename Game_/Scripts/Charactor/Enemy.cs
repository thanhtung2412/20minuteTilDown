using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Charactor
{
    protected Transform target;
    protected Rigidbody2D rb;   
    [SerializeField] protected float speedBot = 3f;

    [SerializeField] private Xp xp;

    public Collider2D myCol;

    public GameObject deathEffect;
    public int damage;
    public bool isMove = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();              
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }
    
    private void OnDisable()
    {       
        if (myCol != null)
        {
            myCol.enabled = true;
        }
        isMove = true;
        health = maxHealth;
    }
    public override void Update()
    {
        base.Update();
        RotateToWardsTarget();
    }
    public override void FixedUpdate()
    {
        base .FixedUpdate();
        MoveToTarget();      
    }
    
    public override void Die()
    {              
       base.Die();
       isMove = false;
       myCol.enabled = false;
    }
    public virtual void EffectDie()
    {
        //Instantiate(xp.gameObject, transform.position, Quaternion.identity);
        SimplePool.Spawn<Xp>(xp, transform.position, Quaternion.identity);
        Instantiate(deathEffect, transform.position, Quaternion.identity);      
    }
    private void RotateToWardsTarget()
    {
        if (target != null)
        {

            Vector2 targetDir = target.position - transform.position;
            if (targetDir.x < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }
        }
    }
    protected virtual void MoveToTarget()
    {
        if (target != null && isMove)
        {
            Vector2 targetDir = target.position - transform.position;
            rb.velocity = targetDir.normalized * speedBot;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {         
            Player player = collision.gameObject.GetComponent<Player>(); 
            if(player != null)
            {
                player.TakeDamage(damage);
                UIGamePlay.heathBar.UpdateHpBar(player.health);
            }
            //target = null;
        }    
    }
}
