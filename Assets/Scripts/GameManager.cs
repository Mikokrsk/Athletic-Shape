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
    [SerializeField] private CanvasGroup _settingsMenuCanvasGroup;
    // [SerializeField] private CanvasGroup _finishLevelCanvasGroup;
    [SerializeField] private CanvasGroup _gameOverCanvasGroup;
    [SerializeField] private CanvasGroup _giftMenuCanvasGroup;
    [SerializeField] private Button _growButton;
    [SerializeField] private Button _shrinkButton;

    [SerializeField] private FinishLevelMenu _finishLevelMenu;

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

    public void LoadLevel(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void ResetLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenSettingsMenu()
    {
        StartPause();
        _settingsMenuCanvasGroup.alpha = 1;
        _settingsMenuCanvasGroup.blocksRaycasts = true;
    }
    public void CloseSettingsMenu()
    {
        StopPause();
        _settingsMenuCanvasGroup.alpha = 0;
        _settingsMenuCanvasGroup.blocksRaycasts = false;
    }

    public void OpenGiftMenu()
    {
        _giftMenuCanvasGroup.alpha = 1;
        _giftMenuCanvasGroup.blocksRaycasts = true;
        var wheel = _giftMenuCanvasGroup.GetComponentInChildren<WheelOfFortune>();
        wheel.GenerateSectors(5);
    }
    public void CloseGiftMenu()
    {
        _giftMenuCanvasGroup.alpha = 0;
        _giftMenuCanvasGroup.blocksRaycasts = false;
    }

    /*    public void OpenFinishLevelMenu()
        {
            StartPause();
            _finishLevelCanvasGroup.alpha = 1;
            _finishLevelCanvasGroup.blocksRaycasts = true;
        }
        public void CloseFinishLevelMenu()
        {
            StopPause();
            _finishLevelCanvasGroup.alpha = 0;
            _finishLevelCanvasGroup.blocksRaycasts = false;
            GoToMainMenu();
        }*/

    public void GoToMainMenu()
    {
        LoadLevel(0);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void StartPause()
    {
        Time.timeScale = 0;
    }
    private void StopPause()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        _growButton.interactable = false;
        _shrinkButton.interactable = false;
        _gameOverCanvasGroup.alpha = 1;
        _gameOverCanvasGroup.blocksRaycasts = true;
    }

    public void FinishLevel()
    {
        _finishLevelMenu.EnableMenu();
    }
}