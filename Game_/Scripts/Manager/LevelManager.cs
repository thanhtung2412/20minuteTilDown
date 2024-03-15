using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject canvasJoystick;
    public Player player;
    public int curXpLevel = 0;
    public int curLevel = 1;
    private void Start()
    {
        UIManager.Instance.OpenUI<UIMenu>();
    }
    public void OnInit()
    {
        player.transform.position = Vector3.zero;
        player.health = player.maxHealth;      
    }
    public void OnStartGame()
    {
        GameManager.Instance.ChangeState(GameState.GamePlay);
        StartGamePlay();
        OnInit();
        canvasJoystick.SetActive(true);
    }
    public void OnReSet()
    {
        SimplePool.CollectAll();
    }
    public void OnReTry()
    {
        OnInit();
        OnReSet();
        canvasJoystick.SetActive(true);
        GameManager.Instance.ChangeState(GameState.GamePlay);
        StartGamePlay();
       

    }
    public void OnPauseGame()
    {
        GameManager.Instance.ChangeState(GameState.Pause);
        canvasJoystick.SetActive(false);
        Time.timeScale = 0;
    }
    private void StartGamePlay() 
    {
        UIManager.Instance.OpenUI<UIGamePlay>();      
    }

}
