using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HpTxt : MonoBehaviour
{
    public TextMeshProUGUI hpTxt;
    [SerializeField] private float timeLife = 2f;
    private void Start()
    {
        Destroy(gameObject, timeLife);
    }
}
