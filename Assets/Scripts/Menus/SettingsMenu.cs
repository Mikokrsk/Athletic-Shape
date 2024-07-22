using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : GameMenu
{
    public static SettingsMenu Instance;

    [SerializeField] private GameObject _goToHomeButton;
    [SerializeField] private GameObject _restartLevelButton;

    public override void Start()
    {
        base.Start();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _goToHomeButton.SetActive(false);
            _restartLevelButton.SetActive(false);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}