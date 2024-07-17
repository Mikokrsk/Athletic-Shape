using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _minSize;
    [SerializeField] private float _maxSize;

    private void OnCollisionEnter(Collision collision)
    {
        var scale = collision.transform.GetComponentInChildren<PlayerSizeController>().GetCurrentSizeY();

        if (scale >= _minSize && scale <= _maxSize)
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