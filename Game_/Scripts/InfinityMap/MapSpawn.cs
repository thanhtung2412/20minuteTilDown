using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    [SerializeField] protected Vector3 spawnPosOffset = new Vector3(0, 0, 0);
    public InfinityMap infinityMap;
    public CheckMap checkMap;
    private void Awake()
    {
        infinityMap = transform.parent.GetComponentInParent<InfinityMap>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!checkMap.isMap)
            {
                SpawnMap();
            }
        }
    }
    protected virtual void SpawnMap()
    {
        Vector3 spawnpos = infinityMap.transform.position;
        spawnpos.x += this.spawnPosOffset.x;
        spawnpos.y += this.spawnPosOffset.y;
        spawnpos.z += this.spawnPosOffset.z;

        GameObject newmap = Instantiate(this.infinityMap.transform.gameObject);
        newmap.transform.position = spawnpos;
    }
}
