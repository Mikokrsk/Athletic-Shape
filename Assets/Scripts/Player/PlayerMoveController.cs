using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed = 1f;

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

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 movement = transform.forward * _moveSpeed;

        _rb.velocity = movement;
    }
}
