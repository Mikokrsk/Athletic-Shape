using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectLevelItem : MonoBehaviour
{
    [SerializeField] private LevelItem _levelShopItem;
    [SerializeField] private string _name;
    [SerializeField] private int _amount;
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private TextMeshProUGUI _amountText;
    [SerializeField] private GameObject _amountObject;
    [SerializeField] private bool _isBuyed = false;

    private string IS_BUYED_KEY;

    public void Start()
    {
        if (_name == "Tutorial Level")
        {
            _isBuyed = true;
        }
        else
        {
            IS_BUYED_KEY = "IS_BUYED_" + _name;
            LoadIsBuyed();
        }
        UpdateUI();
    }

    public void Buy()
    {
        if (Wallet.Instance.SpendMoney(_amount))
        {
            _isBuyed = true;
            UpdateUI();
            SaveIsBuyed();
        }
    }

    private void UpdateUI()
    {
        _playButton.SetActive(_isBuyed);
        _buyButton.SetActive(!_isBuyed);
        _amountObject.SetActive(!_isBuyed);

        if (!_isBuyed)
        {
            _amountText.text = _amount.ToString();
        }
    }

    public void Play()
    {
        GameManager.Instance.SetCurrentLevel(_levelShopItem);
    }

    private void SaveIsBuyed()
    {
        PlayerPrefs.SetInt(IS_BUYED_KEY, _isBuyed ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadIsBuyed()
    {
        _isBuyed = PlayerPrefs.GetInt(IS_BUYED_KEY, 0) == 1;
    }
}
