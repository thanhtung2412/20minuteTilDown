
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public Transform camera1;   
    private Vector3 posTarget;
    [SerializeField] private float damping;
    private Vector3 vel = Vector3.zero;

    void Update()
    {
        posTarget = new Vector3(camera1.position.x, camera1.position.y, 0f);
        if(Vector3.Distance(transform.position, posTarget) >= 2f)
        {
            transform.position = Vector3.Slerp(transform.position, posTarget, damping);
        }
    }
}
