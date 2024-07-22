using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSizeController _playerSizeController;
    [SerializeField] private PlayerMoveController _moveController;
    [SerializeField] private PlayerAnimationController _animationController;

    private void Start()
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
    }

    private void FinishLevel()
    {
        UIManager.Instance.OpenFinishLevelMenu();
    }

    public void RestorePlayerMove()
    {
        _moveController.RestoreMove();
        _animationController.RestorePlayAllAnimatios();
    }

    public void StopPlayerMove()
    {
        _moveController.StopMove();
        _animationController.StopPlayAllAnimations();
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