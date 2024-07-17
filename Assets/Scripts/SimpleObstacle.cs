using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObstacle : Obstacle
{
    protected override void OnCollisionEnter(Collision collision)
    {
        //TODO Game Over
        Debug.Log("GameOver");
    }
}