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
    [SerializeField] private ControlButtonsMenu _controlButtonsMenu;
    [SerializeField] private TutorialMenu _tutorialMenu;
    [SerializeField] private GameObject _GameUI;

    [SerializeField] private LevelLoadManager _levelLoadManager;

    [SerializeField] private GameManager _gameManager;

    public static UIManager Instance;

    private void OnEnable()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        var level = _gameManager.GetCurrentLevel();

        if (level.name == "Tutorial Level")
        {
            _tutorialMenu.EnableMenu();
        }
    }

    public void OpenGameMenuUI()
    {
        CloseAllMenus();

        if (GameManager.Instance.GetCurrentLevel().levelDifficulty == LevelDifficulty.Tutorial)
        {
            OpenTutorialMenu();
        }
        else
        {
            OpenControlButtonsMenu();
        }
    }
    public void OpenMainMenuUI()
    {
        CloseAllMenus();
        if (GameManager.Instance.GetCurrentGameMode() == GameMode.MainMenu)
        {
            OpenShopMenu();
            OpenLevelSelectMenu();
            _settingsMenu.UpdateGameMode();
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
        _summaryMenu.EnableMenu();
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

    public void OpenTutorialMenu()
    {
        OpenMenu(_tutorialMenu);
    }
    public void CloseTutorialMenu()
    {
        CloseMenu(_tutorialMenu);
    }

    public void OpenControlButtonsMenu()
    {
        OpenMenu(_controlButtonsMenu);
    }
    public void CloseControlButtonsMenu()
    {
        CloseMenu(_controlButtonsMenu);
    }

    private void OpenMenu(GameMenu gameMenu)
    {
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
        CloseControlButtonsMenu();
        CloseLevelSelectMenu();
        CloseTutorialMenu();
        CloseShopMenu();
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
        CloseAllMenus();
        _levelLoadManager.GoToMainMenu();
    }

    public void RestartLevel()
    {
        CloseAllMenus();
        _gameManager.RestartLevel();
    }
}