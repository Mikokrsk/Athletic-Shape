using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObstacle : Obstacle
{
    [SerializeField] private float _targetMaxSize;

    public float GetTargetMaxSize()
    {
        return _targetMaxSize;
    }
}