using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    
    private Player player;
    [SerializeField] private GameObject bulletSkill;
    public Meteor meteorPrefab;
    public Dragon dragon;
    public GameObject egg;
    [SerializeField] private int meteorCount = 6;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float timeCall = 2f;
    private void Start()
    {
        player = LevelManager.Instance.player;  
    }
    public void Acceleration()
    {      
        player.speed += player.speed * 2 / 10;
        Debug.Log(player.speed);
    }
    public void IncreaseBullet()
    {
        player.maxBullet++;
        Debug.Log("so dan la :" + player.maxBullet);
    }
    public void RadiantBullets()
    {
        for(int i =0; i< player.pointRadiantBullet.Length; i++)
        {
            Instantiate(bulletSkill, player.pointRadiantBullet[i].position, player.pointRadiantBullet[i].rotation);
        }
    }
    public void MeteorFall()
    {
        Invoke("CreateMeteor", timeCall);
    }
    public void CreateMeteor()
    {
        for (int i = 0; i < meteorCount; i++)
        {           
            float angle = i * (360f / meteorCount);          
            float radianAngle = angle * Mathf.Deg2Rad;         
            Vector3 PointFall = new Vector3(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle), 0f) * radius + player.transform.position;
            Vector3 PointSpawn = new Vector3(PointFall.x, PointFall.y + 10f, 0);
            Meteor meteor = Instantiate(meteorPrefab, PointSpawn, Quaternion.identity);
            meteor.PointFall = PointFall;
            
        }
    }
    public void SpawnDragon()
    {
        GameObject newEgg = Instantiate(egg, player.pointSpawnDragon.position, player.pointSpawnDragon.rotation, player.pointSpawnDragon);
        Destroy(newEgg, 3);
        Invoke("CreateDragon", 3f);
    }
    private void CreateDragon()
    {
        Instantiate(dragon, player.pointSpawnDragon.position, player.pointSpawnDragon.rotation, player.pointSpawnDragon);
    }

    

}
