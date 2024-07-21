using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float _roadLength;
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private Transform _roadPivotTransform;

    private void Start()
    {
        _obstacleSpawner.SetEndSpawnPosition(_roadLength);
        _obstacleSpawner.SpawnObstacles();

        var roadScaleZ = (_obstacleSpawner.GetStartSpawnPosition() + _obstacleSpawner.GetEndSpawnPosition()) / 10;
        _roadPivotTransform.localScale = new Vector3(
            _roadPivotTransform.localScale.x,
            _roadPivotTransform.localScale.y,
            roadScaleZ);
    }
}