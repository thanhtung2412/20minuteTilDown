using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private Image bar;
    [SerializeField] private int  xpLevelMax = 10;
    [SerializeField] private UIGamePlay uiGamePlay;
     
    private void Start()
    {
        UpdateBar(LevelManager.Instance.curLevel);     
    }
    public void UpdateLevelBar(int amountXp)
    {      
        LevelManager.Instance.curXpLevel += amountXp;
        if (LevelManager.Instance.curXpLevel > xpLevelMax)
        {
            LevelManager.Instance.curLevel++;
            LevelManager.Instance.curXpLevel = LevelManager.Instance.curXpLevel - xpLevelMax;
            xpLevelMax = xpLevelMax * 2;
           
            uiGamePlay.OpenLevelUpPnl();
        }
        UpdateBar(LevelManager.Instance.curLevel);
    }
    public void UpdateBar(int curLevel)
    { 
        levelTxt.text = "Level :" + curLevel.ToString();
        bar.fillAmount = (float)LevelManager.Instance.curXpLevel / (float)xpLevelMax;          
    }
    
}
