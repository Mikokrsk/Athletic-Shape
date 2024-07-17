using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _prefabObstacles;
    [SerializeField] protected List<GameObject> _obstaclesList;
    [SerializeField] protected float _startSpawnPositionZ = 5f;
    [SerializeField] protected float _endSpawnPositionZ = 10f;
    [SerializeField] protected float _minDistanceBetweenObstacles = 1f;
    [SerializeField] protected float _maxDistanceBetweenObstacles = 3f;

    private void Start()
    {
        _obstaclesList = new List<GameObject>();
        SpawnObstacle();
    }

    protected void SpawnObstacle()
    {
        var prefabObstacle = GetRandomObstacle();

        if (prefabObstacle != null)
        {
            var obstacle = Instantiate(prefabObstacle, transform);
            obstacle.transform.position = GetSpawnedObstaclePositon();
            _obstaclesList.Add(obstacle);
        }

        var lastObstaclePositionZ = _obstaclesList.Last().transform.position.z;

        if (lastObstaclePositionZ + _minDistanceBetweenObstacles <= _endSpawnPositionZ)
        {
            SpawnObstacle();
        }
    }

    protected GameObject GetRandomObstacle()
    {
        var randomIndex = Random.Range(0, _prefabObstacles.Count);

        return _prefabObstacles[randomIndex];
    }

    protected float GetRandomDistanceBetweenObstacles()
    {
        var randomDistance = Random.Range(_minDistanceBetweenObstacles, _maxDistanceBetweenObstacles);
        var lastObstaclePositionZ = _obstaclesList.Last().transform.position.z;

        if (lastObstaclePositionZ + _maxDistanceBetweenObstacles <= _endSpawnPositionZ)
        {
            return randomDistance;
        }
        else
        {
            return _endSpawnPositionZ;
        }

    }

    protected Vector3 GetSpawnedObstaclePositon()
    {
        if (_obstaclesList.Count == 0)
        {
            return new Vector3(0, 0, _startSpawnPositionZ);
        }
        else
        {
            return new Vector3(0, 0, _obstaclesList.Last().transform.position.z + GetRandomDistanceBetweenObstacles());
        }
    }
}