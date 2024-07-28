using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTutorial : MonoBehaviour
{
    private const string IS_COMPLETED = "isCompleted";

    [SerializeField] private CanvasGroup _mainMenuTutorial;
    [SerializeField] private List<GameObject> _hints;
    [SerializeField] private int _currentHintIndex = 0;
    [SerializeField] private bool _isCompleted;

    private void Awake()
    {
        Enable();
    }

    public void Enable()
    {
        LoadIsCompleted();

        if (!_isCompleted)
        {
            _mainMenuTutorial.alpha = 1;
            _mainMenuTutorial.blocksRaycasts = true;
            _hints[0].SetActive(true);
        }
    }
    public void Disable()
    {
        _mainMenuTutorial.alpha = 0;
        _mainMenuTutorial.blocksRaycasts = false;
        _isCompleted = true;
        SaveIsCompleted();
    }

    public void Next(int index)
    {
        for (int i = 0; i < _hints.Count; i++)
        {
            if (i == index)
            {
                _hints[i].SetActive(true);
            }
            else
            {
                _hints[i].SetActive(false);
            }
        }
    }

    private void SaveIsCompleted()
    {
        if (_isCompleted)
        {
            PlayerPrefs.SetInt(IS_COMPLETED, 1);
        }
        else
        {
            PlayerPrefs.SetInt(IS_COMPLETED, 0);
        }

        PlayerPrefs.Save();
    }

    private void LoadIsCompleted()
    {
        if (PlayerPrefs.GetInt(IS_COMPLETED) == 0)
        {
            _isCompleted = false;
        }
        else
        {
            _isCompleted = true;
        }
    }
}