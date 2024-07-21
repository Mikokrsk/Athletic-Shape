using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevelMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Animator _animator;

    private const string START_COIN_CONFETTI_TRIGGER_NAME = "StartCoinConfetti";

    public static FinishLevelMenu Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void StartConfetti()
    {
        _animator.SetTrigger(START_COIN_CONFETTI_TRIGGER_NAME);
    }

    public void EnableMenu()
    {
        StartConfetti();
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    public void DisableMenu()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }
}