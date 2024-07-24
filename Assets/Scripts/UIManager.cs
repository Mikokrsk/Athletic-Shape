using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private FinishLevelMenu _finishLevelMenu;
    [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private WheelFortuneMenu _wheelFortuneMenu;
    [SerializeField] private SettingsMenu _settingsMenu;
    [SerializeField] private SummaryMenu _summaryMenu;
    [SerializeField] private ShopMenu _shopMenu;
    [SerializeField] private ShopMenu _levelSelectMenu;
    [SerializeField] private GameObject _GameUI;

    [SerializeField] private LevelLoadManager _levelLoadManager;

    public static UIManager Instance;

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

    public void OpenSummaryMenu(int amount)
    {
        _summaryMenu.SetSummary(amount);
        OpenMenu(_summaryMenu);
    }
    public void CloseSummaryMenu()
    {
        CloseMenu(_summaryMenu);
    }

    public void OpenShopMenu()
    {
        OpenMenu(_shopMenu);
    }
    public void CloseShopMenu()
    {
        CloseMenu(_shopMenu);
    }

    public void OpenLevelSelectMenu()
    {
        OpenMenu(_levelSelectMenu);
    }
    public void CloseLevelSelectMenu()
    {
        CloseMenu(_levelSelectMenu);
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

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void GoToHome()
    {
        _levelLoadManager.GoToMainMenu();
    }

    public void RestartLevel()
    {
        _levelLoadManager.RestartLevel();
    }
}