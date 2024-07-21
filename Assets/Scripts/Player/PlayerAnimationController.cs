using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    // [SerializeField] private bool isJumping;

    private const string TRIGGER_JUMP_NAME = "Jump";
    private const string ANIMATION_JUMP_NAME = "PlayerJumpAnimation";

    public void PlayJumpAnimation()
    {
        AnimatorStateInfo currentAnimatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        if (!currentAnimatorStateInfo.IsName(ANIMATION_JUMP_NAME))
        {
            _animator.SetTrigger(TRIGGER_JUMP_NAME);
        }
    }

    public void StopPlayAllAnimations()
    {
        _animator.enabled = false;
    }

    public void RestorePlayAllAnimatios()
    {
        _animator.enabled = true;
    }
}