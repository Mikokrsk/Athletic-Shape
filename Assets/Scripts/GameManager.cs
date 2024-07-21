using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private FinishLevelMenu _finishLevelMenu;
    [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private WheelFortuneMenu _wheelFortuneMenu;
    [SerializeField] private SettingsMenu _settingsMenu;

    public static GameManager Instance;

    private void OnEnable()
    {
        Time.timeScale = 1.0f;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OpenSettingsMenu()
    {
        _settingsMenu.EnableMenu();
    }

    public void OpenWheelFortuneMenu()
    {
        _wheelFortuneMenu.EnableMenu();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void GameOver()
    {
        _gameOverMenu.EnableMenu();
    }

    public void FinishLevel()
    {
        _finishLevelMenu.EnableMenu();
    }
}