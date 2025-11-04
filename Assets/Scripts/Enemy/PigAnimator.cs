using System.Collections;
using UnityEngine;

public class PigAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyAttackDetector _pigAttack;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _pigAttack = GetComponent<EnemyAttackDetector>();
    }

    private void OnEnable()
    {
        _pigAttack.AttackStarted += PlayAttack;       
    }

    private void OnDisable()
    {
        _pigAttack.AttackStarted -= PlayAttack;
    }

    public void PlayAttack()
    {
        _animator.SetBool(GameConstants.AnimatorParams.IsAttack, true);
        StartCoroutine(ResetAttackAfterDelay());
    }

    private IEnumerator ResetAttackAfterDelay()
    {
        yield return new WaitForSeconds(0.3f);

        _animator.SetBool(GameConstants.AnimatorParams.IsAttack, false);
    }
}
