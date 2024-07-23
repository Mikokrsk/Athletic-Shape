using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : GameMenu
{
    private const string OPEN_SHOP_MENU_TRIGGER_NAME = "Open";
    private const string CLOSE_SHOP_MENU_TRIGGER_NAME = "Close";
    [SerializeField] private Animator _animator;

    [SerializeField] private bool _isMenuOpened;

    public override void Start()
    {
        base.Start();
        _isMenuOpened = false;
    }

    public void TogleMenu()
    {
        if (_isMenuOpened)
        {
            DisableMenu();
        }
        else
        {
            EnableMenu();
        }
    }

    public override void EnableMenu()
    {
        //  base.EnableMenu();
        _animator.SetTrigger(OPEN_SHOP_MENU_TRIGGER_NAME);
        _isMenuOpened = true;
    }
    public override void DisableMenu()
    {
        //  base.DisableMenu();
        _animator.SetTrigger(CLOSE_SHOP_MENU_TRIGGER_NAME);
        _isMenuOpened = false;
    }
}