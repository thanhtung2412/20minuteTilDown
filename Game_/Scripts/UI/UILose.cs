using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILose : UICanvas
{
    public void OnHome()
    {     
        GameManager.Instance.IsState(GameState.MainMenu);
        LevelManager.Instance.OnReSet();
        UIManager.Instance.OpenUI<UIMenu>();
        Time.timeScale = 1.0f;
        Close(0f);
    }
    public void OnReTry()
    {
        LevelManager.Instance.OnReTry();
        Time.timeScale = 1.0f;
        Close(0f);
    }
}
