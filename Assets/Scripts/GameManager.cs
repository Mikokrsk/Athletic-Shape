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

    [SerializeField] private Player _player;

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
        OpenMenu(_settingsMenu);
    }
    public void CloseSettingsMenu()
    {
        CloseMenu(_settingsMenu);
    }

    public void OpenWheelFortuneMenu()
    {
        OpenMenu(_wheelFortuneMenu);
    }
    public void CloseWheelFortuneMenu()
    {
        CloseMenu(_wheelFortuneMenu);
    }

    public void OpenGameOverMenu()
    {
        OpenMenu(_gameOverMenu);
    }
    public void CloseGameOverMenu()
    {
        CloseMenu(_gameOverMenu);
    }

    public void OpenFinishLevelMenu()
    {
        OpenMenu(_finishLevelMenu);
    }
    public void CloseFinishLevelMenu()
    {
        CloseMenu(_finishLevelMenu);
    }

    private void OpenMenu(GameMenu gameMenu)
    {
        CloseAllMenus();
        gameMenu.EnableMenu();
    }
    private void CloseMenu(GameMenu gameMenu)
    {
        // CloseAllMenus();
        gameMenu.DisableMenu();
    }

    public void CloseAllMenus()
    {
        CloseSettingsMenu();
        CloseWheelFortuneMenu();
        CloseGameOverMenu();
        CloseFinishLevelMenu();
    }

    public void Pause()
    {
        _player.StopPlayerMove();
    }
    public void Unpause()
    {
        _player.RestorePlayerMove();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}