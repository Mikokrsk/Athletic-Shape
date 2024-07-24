using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _prefabObstacles;
    [SerializeField] protected GameObject _prefabFinishObstacle;
    [SerializeField] protected List<Obstacle> _obstaclesList = new List<Obstacle>();
    [SerializeField] protected float _startSpawnPositionZ = 5f;
    [SerializeField] protected float _endSpawnPositionZ = 10f;
    [SerializeField] protected float _minDistanceBetweenObstacles = 1f;
    [SerializeField] protected float _maxDistanceBetweenObstacles = 3f;

    public void ClearObstacle()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void ResetColliders()
    {
        foreach (Transform child in transform)
        {
            child.GetComponentInChildren<Collider>().enabled = true;
        }
    }
    public float GetStartSpawnPosition()
    {
        return _startSpawnPositionZ;
    }
    public float GetEndSpawnPosition()
    {
        return _endSpawnPositionZ;
    }

    public void SetEndSpawnPosition(float roadLength)
    {
        _endSpawnPositionZ = roadLength + _startSpawnPositionZ;
    }

    public void SpawnObstacles()
    {
        var lastObstaclePositionZ = _startSpawnPositionZ;
        int i = 0;
        _obstaclesList.Clear();
        while (true)
        {
            if (_obstaclesList.Count() > 0)
            {
                lastObstaclePositionZ = _obstaclesList.Last().transform.position.z;
            }

            if (lastObstaclePositionZ + _minDistanceBetweenObstacles <= _endSpawnPositionZ)
            {
                SpawnRandomObstacle();
            }
            else
            {
                SpawnFinishObstacle();
                break;
            }
            i++;
            if (i > 1000)
            {
                break;
            }
        }
    }

    protected void SpawnFinishObstacle()
    {
        var obstacle = Instantiate(_prefabFinishObstacle, transform).GetComponent<Obstacle>();
        obstacle.transform.position = GetSpawnedObstaclePositon(obstacle);
        _obstaclesList.Add(obstacle);
    }

    protected void SpawnRandomObstacle()
    {
        var obstaclePrefab = GetRandomObstacle();

        if (obstaclePrefab != null)
        {
            var obstacle = Instantiate(obstaclePrefab, transform).GetComponent<Obstacle>();
            obstacle.transform.position = GetSpawnedObstaclePositon(obstacle);
            _obstaclesList.Add(obstacle);

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

        return randomDistance;
    }

    protected Vector3 GetSpawnedObstaclePositon(Obstacle obstacle)
    {
        var targetSpawnPosition = obstacle.GetSpawnPosition();

        if (_obstaclesList.Count == 0)
        {
            return new Vector3(
                targetSpawnPosition.x,
                targetSpawnPosition.y,
                _startSpawnPositionZ);
        }
        else
        {
            var lastObstacle = _obstaclesList.Last().transform;
            return new Vector3(
                targetSpawnPosition.x,
                targetSpawnPosition.y,
                lastObstacle.transform.position.z + GetRandomDistanceBetweenObstacles());
        }
    }
}