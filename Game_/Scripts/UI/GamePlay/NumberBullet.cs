using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberBullet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberBulletTxt;
    private int maxNumberBullet;

    private void Start()
    {
        if (LevelManager.Instance.player != null)
        {
            maxNumberBullet = LevelManager.Instance.player.maxBullet;
            UpdateNumberBullet(maxNumberBullet, maxNumberBullet);
        }
    }
    public void UpdateNumberBullet(int curBullet, int maxNumberBullet)
    {
        numberBulletTxt.text = "00"+curBullet.ToString()+"/"+"00"+maxNumberBullet.ToString();
    }
}
