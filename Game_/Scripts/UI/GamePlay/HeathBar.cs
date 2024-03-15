using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpTxt;
    [SerializeField] private Image hpBar;
    private int maxHp;
    private void Start()
    {
        if (LevelManager.Instance.player != null)
        {
            maxHp = LevelManager.Instance.player.health;
            UpdateHpBar(maxHp);
        }
    }

    public void UpdateHpBar(int curHp)
    {
        hpTxt.text = curHp.ToString()+ "/" + maxHp.ToString();
        hpBar.fillAmount = (float)curHp / (float)maxHp;
    }
}
