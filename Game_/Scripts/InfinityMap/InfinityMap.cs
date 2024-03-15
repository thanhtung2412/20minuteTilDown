using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityMap : MonoBehaviour
{
    public Transform player;
    public float currentDis = 0f;
    public float limitDis = 80f;

    protected void LateUpdate()
    {
        this.GetDistance();
        this.Despawning();
    }

    protected void Despawning()
    {
        if (this.currentDis < this.limitDis) return;
        Destroy(gameObject);
    }

    protected virtual void GetDistance()
    {
        this.currentDis = Vector3.Distance(this.player.position, transform.position);
    }
}
