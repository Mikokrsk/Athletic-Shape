using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Player _player;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private LevelLoadManager _levelLoadManager;
    [SerializeField] private GameObject _mainMenuCamera;
    [SerializeField] private GameObject _gameCamera;
    [SerializeField] private GameMode _gameMode;
    [SerializeField] private LevelItem _currentLevel;
    [SerializeField] private ObstacleSpawner _obstacleSpawner;

    public static GameManager Instance;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
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
        UpdateUISetup();
        PlayerStartSetup();
        CreateLevel();
    }

    private void CreateLevel()
    {
        _obstacleSpawner.ClearObstacle();
        if (_gameMode == GameMode.Game && _currentLevel.levelDifficulty != LevelDifficulty.Tutorial)
        {
            _levelManager.CreateLevel(_currentLevel._roadLength);
        }
    }

    private void PlayerStartSetup()
    {
        if (_gameMode == GameMode.MainMenu)
        {
            _player.StopMove();
        }
        else
        {
            _player.RestoreMove();
            _player.RestorePlayerAction();
            _player.transform.position = Vector3.zero;
        }
    }
    private void UpdateUISetup()
    {
        if (_gameMode == GameMode.MainMenu)
        {
            _uiManager.OpenMainMenuUI();
        }
        else
        {
            _uiManager.OpenGameMenuUI();
        }
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
    public void RestartLevel()
    {
        _player.transform.position = Vector3.zero;
        _player.RestorePlayerAction();
        _obstacleSpawner.ResetColliders();
        _uiManager.OpenGameMenuUI();
    }
}

public enum GameMode
{
    MainMenu,
    Game
}