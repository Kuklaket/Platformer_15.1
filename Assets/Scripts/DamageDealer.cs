using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private EnemyAttackHandler _enemyAttack;
    [SerializeField] private PlayerAttackHandler _playerAttack;

    //private void OnEnable()
    //{
    //    _enemyAttack.PlayerAttacked += TakeDamage;
    //    _playerAttack.EnemyAttacked += TakeDamage;
    //}

    //private void OnDisable()
    //{
    //    _enemyAttack.PlayerAttacked -= TakeDamage;
    //    _playerAttack.EnemyAttacked -= TakeDamage;
    //}
    
    //private void TakeDamage( BattleEntity attackTarget, int damage)
    //{
    //    attackTarget.HandlerDamage(damage);
    //}
}
