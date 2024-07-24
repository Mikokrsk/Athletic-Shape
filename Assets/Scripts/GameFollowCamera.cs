using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
