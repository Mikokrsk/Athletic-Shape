using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private float _volumeValue;
    [SerializeField] private Slider _volumeValueSlider;
    [SerializeField] private Sprite _muteSoundImage;
    [SerializeField] private Sprite _unmuteSoundImage;
    [SerializeField] private Image _soundImage;

    private void Start()
    {
        MuteSound();
        UpdateVolumeValue();
    }

    public void UpdateVolumeValue()
    {
        _volumeValue = _volumeValueSlider.value;
        _soundImage.sprite = _muteSoundImage;

        if (_volumeValue == 0)
        {
            MuteSound();
        }
        else
        {
            UnmuteSound();
        }
    }

    public void ToggleSound()
    {
        if (_volumeValue == 0)
        {
            _volumeValueSlider.value = 0.25f;
            UnmuteSound();
        }
        else
        {
            MuteSound();
        }
    }

    private void MuteSound()
    {
        _volumeValue = 0;
        _volumeValueSlider.value = 0;
        _soundImage.sprite = _muteSoundImage;
    }
    private void UnmuteSound()
    {
        _volumeValue = _volumeValueSlider.value;
        _soundImage.sprite = _unmuteSoundImage;
    }
}