using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Charactor : GameUnit
{
    public int health;
    public int maxHealth;
    private string curAnim;
    [SerializeField] private Animator anim;
    public GameObject skin;
    public HpTxt hpEffect;
    public virtual void Update()
    {

    }
    public virtual void FixedUpdate()
    {

    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
            if(this is Player)
            {
                Debug.Log("You die");
            }
        }
    }
    public void TakeDameEffect(int dame)
    {
        if(hpEffect != null)
        {
            HpTxt newHpEff = Instantiate(hpEffect, transform.position + new Vector3(Random.Range(-0.3f,0.3f),0.5f,0), Quaternion.identity);
            newHpEff.hpTxt.text = dame.ToString();          
        }
    }
    public virtual void Die()
    {
        
    }
    public void ChangeAnim(string animName)
    {
        if (curAnim != animName)
        {
            anim.ResetTrigger(animName);
            curAnim = animName;
            anim.SetTrigger(animName);
        }
    }
}
