using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GroundDetector _groundDetector;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void OnEnable()
    {
        _playerMover.MovementStateChanged += HandleMovementStateChange;
        _groundDetector.GroundedChanged += HandleGroundedChange;
    }

    private void OnDisable()
    {
        _playerMover.MovementStateChanged -= HandleMovementStateChange;
        _groundDetector.GroundedChanged -= HandleGroundedChange;
    }

    public void PlayRun()
    {
        _animator.SetBool(GameConstants.AnimatorParams.IsRun, true);
        _animator.SetBool(GameConstants.AnimatorParams.IsJump, false);
        _animator.SetBool(GameConstants.AnimatorParams.IsIdle, false);
        _animator.SetBool(GameConstants.AnimatorParams.IsAttack, false);
    }

    public void PlayIdle()
    {
        _animator.SetBool(GameConstants.AnimatorParams.IsRun, false);
        _animator.SetBool(GameConstants.AnimatorParams.IsJump, false);
        _animator.SetBool(GameConstants.AnimatorParams.IsIdle, true);
        _animator.SetBool(GameConstants.AnimatorParams.IsAttack, false);
    }

    public void PlayJump()
    {
        _animator.SetBool(GameConstants.AnimatorParams.IsRun, false);
        _animator.SetBool(GameConstants.AnimatorParams.IsJump, true);
        _animator.SetBool(GameConstants.AnimatorParams.IsIdle, false);
        _animator.SetBool(GameConstants.AnimatorParams.IsAttack, false);
    }

    public void PlayAttack()
    {
        _animator.SetBool(GameConstants.AnimatorParams.IsAttack, true);
    }

    public void StopAttack()
    {
        _animator.SetBool(GameConstants.AnimatorParams.IsAttack, false);
    }

    private void HandleMovementStateChange(bool isRunning)
    {
        if (_groundDetector.IsGrounded)
        {
            if (isRunning)
                PlayRun();
            else 
                PlayIdle();
        }
    }

    private void HandleGroundedChange(bool isGrounded)
    {
        if (isGrounded)
        {
            if (_playerMover.IsRunning)
                PlayRun();
            else
                PlayIdle();
        }
        else
        {
            PlayJump();
        }
    }
}