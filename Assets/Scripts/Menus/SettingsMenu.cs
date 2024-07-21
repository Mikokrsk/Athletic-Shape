using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : GameMenu
{
    public static SettingsMenu Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}