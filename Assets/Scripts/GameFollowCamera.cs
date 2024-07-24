using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private bool isRotation;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    public void SetRotation(bool isRotation)
    {
        this.isRotation = isRotation;
        transform.rotation = Quaternion.identity;
    }

    public void StartRotation()
    {
        isRotation = true;
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;
        if (isRotation)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        transform.Rotate(transform.forward, rotationSpeed);
    }
}
