using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private int waveNumber = 5;
    public int enemiesAmount = 0;
    public Enemy[] enemyPb;
    public Camera cam;
    public float timeSpawnRate;
    private float timeSpawn;
    void Start()
    {
        cam = Camera.main;        
    }

    // Update is called once per frame
    void Update()
    {
        float height = cam.orthographicSize;      
        float width = height * cam.aspect;
        if (GameManager.Instance.IsState(GameState.GamePlay))
        {
            if (timeSpawn <= 0)
            {
                timeSpawn = timeSpawnRate;
                for (int i = 0; i < waveNumber; i++)
                {
                    int rand = Random.Range(0, 4);
                    int randenemyPB = Random.Range(0, enemyPb.Length);
                    if (rand == 0)
                    {
                        //Enemy enemy = Instantiate(enemyPb[randenemyPB], new Vector3(cam.transform.position.x - width - Random.Range(5, 10), cam.transform.position.y + Random.Range(-height, height), 0), Quaternion.identity);
                        SimplePool.Spawn<Enemy>(enemyPb[randenemyPB], new Vector3(cam.transform.position.x - width - Random.Range(5, 10), cam.transform.position.y + Random.Range(-height, height), 0), Quaternion.identity);
                        enemiesAmount++;
                    }
                    else if (rand == 1)
                    {
                        SimplePool.Spawn<Enemy>(enemyPb[randenemyPB], new Vector3(cam.transform.position.x + width + Random.Range(5, 10), cam.transform.position.y + Random.Range(-height, height), 0), Quaternion.identity);
                        enemiesAmount++;
                    }
                    else if (rand == 2)
                    {
                        SimplePool.Spawn<Enemy>(enemyPb[randenemyPB], new Vector3(cam.transform.position.x + Random.Range(5, 10), cam.transform.position.y + height + Random.Range(-height, height), 0), Quaternion.identity);
                        enemiesAmount++;
                    }
                    else
                    {
                        SimplePool.Spawn<Enemy>(enemyPb[randenemyPB], new Vector3(cam.transform.position.x + Random.Range(5, 10), cam.transform.position.y - height - Random.Range(-height, height), 0), Quaternion.identity);
                        enemiesAmount++;
                    }

                }
            }
            else
            {
                timeSpawn -= Time.deltaTime;
            }
        }
    }
}

