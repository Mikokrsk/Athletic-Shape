using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] protected Vector3 _spawnPosition;
    //[SerializeField] protected Quaternion _spawnRotation;

    protected abstract void OnCollisionEnter(Collision collision);
}
