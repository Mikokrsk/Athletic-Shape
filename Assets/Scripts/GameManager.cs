using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _uiManager;
    [SerializeField] private GameObject _player;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private LevelLoadManager _levelLoadManager;
    [SerializeField] private GameObject _mainMenuCamera;
    [SerializeField] private GameObject _gameCamera;
    [SerializeField] private GameMode _gameMode;
    [SerializeField] private LevelItem _currentLevel;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

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

        CamerasSetup();
    }

    private void CamerasSetup()
    {
        if (_gameMode == GameMode.MainMenu)
        {
            _mainMenuCamera.SetActive(true);
            _gameCamera.SetActive(false);
        }
        else
        {
            _mainMenuCamera.SetActive(false);
            _gameCamera.SetActive(true);
        }
    }

    public Player GetPlayer()
    {
        return _player.GetComponent<Player>();
    }

    public GameMode GetCurrentGameMode()
    {
        return _gameMode;
    }

    public void SetCurrentLevel(LevelItem currentLevel)
    {
        _currentLevel = currentLevel;
        LoadLevel();
    }
    public LevelItem GetCurrentLevel()
    {
        return _currentLevel;
    }

    public void LoadLevel()
    {
        if (_currentLevel != null)
        {
            if (_currentLevel.name == "Tutorial Level" || GetCurrentGameMode() == GameMode.MainMenu)
            {
                _levelLoadManager.LoadLevel(_currentLevel.levelLoadIndex);
            }
        }
    }
}

public enum GameMode
{
    MainMenu,
    Game
}