using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelFortuneMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private WheelOfFortune _wheelOfFortune;

    public static WheelFortuneMenu Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void EnableMenu()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;

        _wheelOfFortune.GenerateSectors(5);
    }

    public void DisableMenu()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }
}