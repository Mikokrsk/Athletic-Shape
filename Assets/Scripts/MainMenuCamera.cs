using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public Transform player;
    public float distance = 5.0f;
    public float orbitSpeed = 10.0f;
    public float angleY = -20f;

    private float angleX = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        angleX = angles.y;
    }

    void LateUpdate()
    {
        if (player)
        {
            angleX += orbitSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(angleY, angleX, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + player.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}