using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 1.0f;
    }

    [SerializeField] private CanvasGroup _settingsMenuCanvasGroup;

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
}