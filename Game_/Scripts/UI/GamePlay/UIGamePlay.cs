using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePlay : UICanvas
{
    [SerializeField] private GameObject levelUpPnl;
    public static LevelBar levelBar;
    public  static HeathBar heathBar;
    public static NumberBullet numberBullet;
    private void Start()
    {
        levelBar = GetComponentInChildren<LevelBar>();
        heathBar = GetComponentInChildren<HeathBar>();
        numberBullet = GetComponentInChildren<NumberBullet>();
    }
    
    public void CloseLevelUpPnl()
    {
        CanvasGroup cans = levelUpPnl.GetComponent<CanvasGroup>();
        cans.alpha = 0f;
        cans.blocksRaycasts = false;
        cans.interactable = false;       
        LevelManager.Instance.canvasJoystick.SetActive(true);
        Time.timeScale = 1;
    }

    public void OpenLevelUpPnl()
    {
        CanvasGroup cans = levelUpPnl.GetComponent<CanvasGroup>();
        cans.alpha = 1f;
        cans.blocksRaycasts = true;
        cans.interactable = true;
        LevelManager.Instance.canvasJoystick.SetActive(false);
        Time.timeScale = 0;
    }
    public void OpenSetting()
    {       
        LevelManager.Instance.canvasJoystick.SetActive(false);
        LevelManager.Instance.OnPauseGame();
        UIManager.Instance.OpenUI<UISetting>();
        Close(0f);
    }
}
