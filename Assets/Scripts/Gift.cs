using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class Gift : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] public float cost;

    public RectTransform GetRotation()
    {
        return rectTransform;
    }

    public void SetRotation(float angleZ)
    {
        rectTransform.transform.localRotation = Quaternion.Euler(0, 0, angleZ);
    }
}