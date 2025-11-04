using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private EnemyAttackDetector _enemyAttack;
    [SerializeField] private PlayerAttackDetector _playerAttack;

    private void OnEnable()
    {
        _enemyAttack.PlayerAttacked += TakeDamage;
        _playerAttack.EnemyAttacked += TakeDamage;
    }

    private void OnDisable()
    {
        _enemyAttack.PlayerAttacked -= TakeDamage;
        _playerAttack.EnemyAttacked -= TakeDamage;
    }
    
    private void TakeDamage( BattleEntity attackTarget, int damage)
    {
        attackTarget.HandlerDamage(damage);
    }
}
