using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : UICanvas
{
    public void OnPlayGame()
    {
        SoundManager.Instance.soundClick.Play();
        LevelManager.Instance.OnStartGame();      
        Close(0.5f);
    }
}
