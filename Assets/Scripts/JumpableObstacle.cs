using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpableObstacle : Obstacle
{
    [SerializeField] private float _targetMinSize;

    public float GetTargetMinSize()
    {
        return _targetMinSize;
    }
}