using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButtonsMenu : GameMenu
{
    public void Grow()
    {
        GameManager.Instance.GetPlayer().Grow();
    }

    public void Shrink()
    {
        GameManager.Instance.GetPlayer().Shrink();
    }
}