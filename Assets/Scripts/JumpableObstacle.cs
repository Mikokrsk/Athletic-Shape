using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpableObstacle : Obstacle
{
    [SerializeField] private float _minSize;

    protected override void OnCollisionEnter(Collision collision)
    {
        var scale = collision.transform.GetComponentInChildren<PlayerSizeController>().GetCurrentSize();

        if (scale >= _minSize)
        {
            //TODO Jump or another actions
            gameObject.SetActive(false);
        }
        else
        {
            //TODO Game Over
            Debug.Log("GameOver");
        }
    }
}