using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeController : MonoBehaviour
{
    [SerializeField] private Transform _pivotTransform;
    [SerializeField] private float _sizeChangeSpeed;
    [SerializeField] private float _minSize;
    [SerializeField] private float _maxSize;
    [SerializeField] private float _duration;
    [SerializeField] private float _maxDuration;
    //[SerializeField] private float _maxSmallSizePlayer;
    [SerializeField] private float _minLargeSizePlayer;
    private Coroutine _sizeChangeCoroutine;

    /*    void ChangePlayerScale(float direction)
        {
            var newScaleY = _pivotTransform.transform.localScale.y + direction * _sizeChangeSpeed * Time.deltaTime;

            if (newScaleY <= _maxSizeY && newScaleY >= _minSizeY)
            {
                _pivotTransform.transform.localScale =
                    new Vector3(_pivotTransform.transform.localScale.x, newScaleY, _pivotTransform.transform.localScale.z);
            }
        }*/

    public void Grow()
    {
        if (_sizeChangeCoroutine != null)
        {
            StopCoroutine(_sizeChangeCoroutine);
        }
        _sizeChangeCoroutine = StartCoroutine(ChangePlayerScale(1));
    }

    public void Shrink()
    {
        if (_sizeChangeCoroutine != null)
        {
            StopCoroutine(_sizeChangeCoroutine);
        }
        _sizeChangeCoroutine = StartCoroutine(ChangePlayerScale(-1));
    }

    private IEnumerator ChangePlayerScale(float direction)
    {
        _duration = _maxDuration;

        while (_duration > 0)
        {
            var newScale = _pivotTransform.transform.localScale.x + direction * _sizeChangeSpeed * Time.deltaTime;

            if (newScale <= _maxSize && newScale >= _minSize)
            {
                _pivotTransform.transform.localScale =
                    new Vector3(newScale, newScale, newScale);
            }
            yield return null;
            _duration -= Time.deltaTime;
        }
    }

    public float GetCurrentSize()
    {
        return _pivotTransform.localScale.x;
    }
}