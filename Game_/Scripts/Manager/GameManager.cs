using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { MainMenu, GamePlay, Pause}
public class GameManager : Singleton<GameManager>
{
    private GameState gameState;
    private void Start()
    {
        gameState = GameState.MainMenu;
    }
    public void ChangeState(GameState state)
    {
        this.gameState = state;
    }
    public bool IsState(GameState state)
    {
        return this.gameState == state;
    }
}
