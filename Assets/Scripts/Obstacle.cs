using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;

    private void OnCollisionEnter(Collision collision)
    {
        var scaleY = collision.transform.GetComponentInChildren<PlayerSizeController>().GetCurrentSizeY();

        if (scaleY >= _minDistance && scaleY <= _maxDistance)
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