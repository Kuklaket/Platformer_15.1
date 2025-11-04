using System;
using System.Collections;
using UnityEngine;

public class PlayerAttackDetector : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private Player _player;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private RaycastHandler _raycastHandler;
    [SerializeField] private float _attackResetDelay = 1f;

    public event Action<BattleEntity,int> EnemyAttacked;

    private void Awake()
    {
        _characterAnimator = _player.GetComponent<CharacterAnimator>();
    }

    private void OnEnable()
    {
        _inputReader.AttackPressed += TryAttack;
    }
    private void OnDisable()
    {
        _inputReader.AttackPressed -= TryAttack;
    }

    private void TryAttack()
    {
        if (_player.TryGetComponent<Stats>(out Stats stats))
        {
            if (stats.CanAttack)
            {
                AttackHandler();
                stats.StartAttackCooldown();
            }
        }
    } 

    private void AttackHandler()
    {
        _characterAnimator?.PlayAttack();

        Vector2 direction = transform.right;

        if (_raycastHandler.CheckRayHit(direction, _targetLayer, out BattleEntity enemy))
        {
            EnemyAttacked?.Invoke(enemy, _player.GetAttack());
        }

        StartCoroutine(ResetAttackAfterDelay());
    }

    private IEnumerator ResetAttackAfterDelay()
    {
        yield return new WaitForSeconds(_attackResetDelay);

        _characterAnimator?.StopAttack();
    }
}