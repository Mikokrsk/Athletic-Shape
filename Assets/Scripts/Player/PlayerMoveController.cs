using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private bool _isMoving = false;

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }

    public void SetMoveSpeed(float speed)
    {
        if (speed >= 0)
        {
            _moveSpeed = speed;
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            _isMoving = true;
        }
    }

    void FixedUpdate()
    {
        if (_isMoving)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 movement = transform.forward * _moveSpeed;

        _rb.velocity = movement;
    }

    public void StopMove()
    {
        _isMoving = false;
        _rb.velocity = Vector3.zero;
    }
    public void RestoreMove()
    {
        _isMoving = true;
    }
}