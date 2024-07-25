using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private Transform _roadPivotTransform;

    public void CreateLevel(float roadLength)
    {
        _obstacleSpawner.SetEndSpawnPosition(roadLength);
        _obstacleSpawner.SpawnObstacles();

        var roadScaleZ = (_obstacleSpawner.GetStartSpawnPosition() + _obstacleSpawner.GetEndSpawnPosition()) / 10 + 2;
        _roadPivotTransform.localScale = new Vector3(
            _roadPivotTransform.localScale.x,
            _roadPivotTransform.localScale.y,
            roadScaleZ);
    }
}