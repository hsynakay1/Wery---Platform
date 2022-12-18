using System;
using UnityEngine;

public enum GameStade
{
    UI,
    GamePlay
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameStade gameStade;
    private bool _isInGame;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameStade = GameStade.GamePlay;
        StadeSelector();
    }

    public void StadeSelector()
    {
        switch (gameStade)
        {
            case GameStade.UI:
                EventManager.Instance.LevelStart();
                break;
            case GameStade.GamePlay:
                EventManager.Instance.GamePlay();
                break;
        }
    }
    
}
