using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetting : UICanvas
{
    public void OnHome()
    {
        GameManager.Instance.IsState(GameState.MainMenu);
        LevelManager.Instance.OnReSet();
        UIManager.Instance.OpenUI<UIMenu>();
        Time.timeScale = 1.0f;
        Close(0f);
    }
    public void OnContinue()
    {
        Time.timeScale = 1.0f;
        Close(0.5f);
        LevelManager.Instance.canvasJoystick.SetActive(true);
        GameManager.Instance.ChangeState(GameState.GamePlay);
        UIManager.Instance.OpenUI<UIGamePlay>();
        Time.timeScale = 1.0f;
        Close(0f);
    }
}
