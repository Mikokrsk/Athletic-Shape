using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSizeController _playerSizeController;
    [SerializeField] private PlayerMoveController _moveController;
    [SerializeField] private PlayerAnimationController _animationController;

    public List<BodyPartRendererPair> bodyPartRendererPairs;

    private void OnEnable()
    {
        if (_playerSizeController == null)
        {
            _playerSizeController = GetComponentInChildren<PlayerSizeController>();
        }
        if (_moveController == null)
        {
            _moveController = GetComponentInChildren<PlayerMoveController>();
        }
        if (_animationController == null)
        {
            _animationController = GetComponentInChildren<PlayerAnimationController>();
        }
    }

    public void Grow()
    {
        _playerSizeController.Grow();
    }

    public void Shrink()
    {
        _playerSizeController.Shrink();
    }

    public void ChangeTexture(TexturesShopItem texturesShopItem)
    {
        foreach (var pair in bodyPartRendererPairs)
        {
            var texture = texturesShopItem.formParts.Find(x => x.bodyPart == pair.bodyPart).texture;

            if (texture != null)
            {
                pair.renderer.material.SetTexture("_MainTex", texture);
            }
        }
    }

    private void CheckCollision(Obstacle obstacle)
    {
        if (obstacle is JumpableObstacle)
        {
            var jumpableObstacle = obstacle as JumpableObstacle;
            if (_playerSizeController.GetCurrentSize() >= jumpableObstacle.GetTargetMinSize())
            {
                _animationController.PlayJumpAnimation();
            }
            else
            {
                GameOver();
            }
        }

        if (obstacle is SimpleObstacle)
        {
            var simpleObstacle = obstacle as SimpleObstacle;
            if (_playerSizeController.GetCurrentSize() >= simpleObstacle.GetTargetMaxSize())
            {
                GameOver();
            }
        }

        if (obstacle is FinishObstacle)
        {
            FinishLevel();
        }
    }

    private void GameOver()
    {
        UIManager.Instance.OpenGameOverMenu();
        StopPlayerAction();
    }

    private void FinishLevel()
    {
        StopPlayerAction();
        UIManager.Instance.OpenFinishLevelMenu();
    }

    public void RestorePlayerAction()
    {
        _moveController.RestoreMove();
        _animationController.RestorePlayAllAnimatios();
    }
    public void StopPlayerAction()
    {
        _moveController.StopMove();
        _animationController.StopPlayAllAnimations();
    }

    public void RestoreMove()
    {
        _moveController.RestoreMove();
        _animationController.RestorePlayAllAnimatios();
        _playerSizeController.Shrink();
    }
    public void StopMove()
    {
        _moveController.StopMove();
        _animationController.RestorePlayAllAnimatios();
        _playerSizeController.Shrink();
    }

    private void OnTriggerEnter(Collider other)
    {
        var obtacle = other.GetComponent<Obstacle>();

        if (obtacle != null)
        {
            obtacle.DisableCollider();
            CheckCollision(obtacle);
        }
    }
}

[Serializable]
public struct BodyPartRendererPair
{
    public BodyPart bodyPart;
    public Renderer renderer;
}