using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _sizeChangeSpeed;
    [SerializeField] private float _minSizeY;
    [SerializeField] private float _maxSizeY;

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ChangePlayerScale(1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            ChangePlayerScale(-1);
        }
    }

    void ChangePlayerScale(float direction)
    {
        var newScaleY = transform.localScale.y + direction * _sizeChangeSpeed * Time.deltaTime;

        if (newScaleY <= _maxSizeY && newScaleY >= _minSizeY)
        {
            transform.localScale = new Vector3(transform.localScale.x, newScaleY, transform.localScale.z);
        }
    }
}