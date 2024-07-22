using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private float _volumeValue;
    [SerializeField] private Slider _volumeValueSlider;

    private void Start()
    {
        UpdateVolumeValue();
    }

    public void UpdateVolumeValue()
    {
        _volumeValue = _volumeValueSlider.value;
    }
}