using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private const string MONEY_KEY = "PlayerMoney";

    [SerializeField] private TextMeshProUGUI _MoneyText;

    public int Money { get; private set; }

    public static Wallet Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        LoadMoney();
    }

    private void UpdateMoneyText()
    {
        _MoneyText.text = Money.ToString();
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        SaveMoney();
        UpdateMoneyText();
    }

    public void SpendMoney(int amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            SaveMoney();
            UpdateMoneyText();
        }
        else
        {
            Debug.Log("Not enough coin win more");
        }
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetInt(MONEY_KEY, Money);
        PlayerPrefs.Save();
    }

    private void LoadMoney()
    {
        Money = PlayerPrefs.GetInt(MONEY_KEY, 0);
        UpdateMoneyText();
    }
}