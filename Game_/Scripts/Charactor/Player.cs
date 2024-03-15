using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Charactor
{
    
    [SerializeField] private GameObject bulletPlayerPb;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private float rangeShoot;
    [SerializeField] private GameObject gun;

    
    [SerializeField] private ReloadBar reloadBar;
  
    public Transform[] pointRadiantBullet;
    public Transform pointSpawnDragon;
    public float speed = 5f;
    public float fireRate;
    private float timeToFire;

    public int maxBullet = 6;
    private int curBullet = 0;
    public float reloadTime = 1;
   

    private bool isMoving = false;   
    private bool isRotate = false;
    private bool isReload = false;  

    private void Start()
    {      
        curBullet = maxBullet;        
    }
    public override void Update()
    {     
        base.Update();
        
        if (curBullet <= 1 && !isReload)
        {                             
            reloadBar.gameObject.SetActive(true);
            reloadBar.Reload();
            isReload = true;
            StartCoroutine(Reload());          
        }
        isMoving = Input.GetMouseButton(0);       
        timeToFire -= Time.deltaTime;
        if(timeToFire < 0 && curBullet >=1)
        {
            bool isShoot = CheckEnemy();
            if (isShoot) 
            {
                PlayerShoot();
            }           
        }            
                         
    }
    public override void FixedUpdate()
    {     
        base.FixedUpdate();
        if (isMoving)
        {
            PlayerMovement();
        }
        else
        {
            rb.velocity = Vector2.zero;
            ChangeAnim("idle");
        }
    }
    private void PlayerMovement()
    {
        Vector2 dir = JoystickControll.direct;
        if (!isRotate)
        {
            if (dir.x < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }
        }
        rb.velocity = dir.normalized * speed ;
        ChangeAnim("walk");
    }

    private IEnumerator Reload()
    {                 
        yield return new WaitForSeconds(reloadTime);
        curBullet = maxBullet;
        isReload = false;
    }
    
  
    public override void Die()
    {
        base.Die();
        UIManager.Instance.OpenUI<UILose>();
        UIManager.Instance.CloseUI<UIGamePlay>();
        LevelManager.Instance.OnPauseGame();
    }
 
    private bool CheckEnemy()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, rangeShoot);  

        for(int i = 0; i < collider.Length; i++)
        {
            Enemy enemy = collider[i].gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {                                          
                isRotate = true;                                         
                CheckRotate(enemy.transform);
                return true;
            }
            else
            {
                isRotate = false;             
            }          
        }
        return false;
    }
    private void CheckRotate(Transform enemy)
    {
        Vector2 lookDir = enemy.transform.position - transform.position;
        if (lookDir.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gun.transform.rotation = rotation;
        if (gun.transform.eulerAngles.z > 90 && gun.transform.eulerAngles.z < 270)
        {
            gun.transform.localScale = new Vector3(1, -1, 0);
        }
        else
        {
            gun.transform.localScale = new Vector3(1, 1, 0);
        }
    }
    private void PlayerShoot()
    {                   
        SoundManager.Instance.soundEff.Play();
        SimplePool.Spawn<BulletEnemy>(PoolType.BulletPlayer, firingPoint.position, firingPoint.rotation);
        curBullet--;
        UIGamePlay.numberBullet.UpdateNumberBullet(curBullet, maxBullet);
        timeToFire = fireRate;                                        
    }
}
