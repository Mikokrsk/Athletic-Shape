using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _uiManager;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _loadLevelManager;
    [SerializeField] private GameObject _mainMenuCamera;
    [SerializeField] private GameMode _gameMode;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _gameMode = GameMode.MainMenu;
        }
        else
        {
            _gameMode = GameMode.Game;
        }
    }

    enum GameMode
    {
        MainMenu,
        Game
    }
}