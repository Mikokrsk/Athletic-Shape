using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] protected Vector3 _spawnPosition;

    public virtual Vector3 GetSpawnPosition()
    {
        return _spawnPosition;
    }

    public virtual void DisableCollider()
    {
        var collider = GetComponent<Collider>();
        collider.enabled = false;
    }
}
