using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadManager : MonoBehaviour
{
    [SerializeField] private int _mainMenuIndex;

    public void GoToMainMenu()
    {
        LoadLevel(_mainMenuIndex);
    }

    public void LoadLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }

    public void RestartLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(LevelItem levelShopItem)
    {
        SceneManager.LoadScene(levelShopItem.levelLoadIndex);
    }
}