using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop/Level Item")]

public class LevelItem : ScriptableObject
{
    public int amount;
    public int levelLoadIndex;
    public LevelDifficulty levelDifficulty;
}

public enum LevelDifficulty
{
    Tutorial,
    Easy,
    Medium,
    Hard,
}