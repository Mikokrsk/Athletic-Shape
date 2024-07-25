using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _grassPrefabs = new List<GameObject>();
    [SerializeField] private MeshCollider _roadCollider;
    [SerializeField] private Transform _roadTransform;
    [SerializeField] private int _counts;
    [SerializeField] private int _currentCounts = 0;

    public void ClearGrass()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SpawnGrass()
    {
        int i = 0;
        _currentCounts = 0;
        _currentCounts = (int)(_counts * _roadTransform.lossyScale.z);
        Debug.Log((int)_counts * _roadTransform.lossyScale.z);
        while (i < _currentCounts)
        {
            Bounds bounds = _roadCollider.bounds;

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);

            Vector3 spawnPosition = new Vector3(randomX, bounds.min.y, randomZ);
            Instantiate(_grassPrefabs[GetRandomGrassIndex()], spawnPosition, Quaternion.identity, transform);
            i++;
        }
    }

    private int GetRandomGrassIndex()
    {
        var index = Random.Range(0, _grassPrefabs.Count);
        return index;
    }
}