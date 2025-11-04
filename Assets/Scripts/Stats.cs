using System;
using System.Collections;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _attack;
    [SerializeField] private int _cooldown;

    private int _maxHealth = 100;
    private bool _canAttack = true;

    public int Health { get => _health; private set => _health = value; }
    public int Attack { get => _attack; private set => _attack = value; }
    public int Cooldown { get => _cooldown; private set => _cooldown = value; }
    public bool CanAttack { get => _canAttack; private set => _canAttack = value; }

    public event Action Died;

    public void GetDamage(int damageCount)
    {
        Health -= damageCount;

        if (Health <= 0)
            Died?.Invoke();
    }

    public void AddHealth(int healthCount)
    {
        int finalyHealth = Health + healthCount;

        if (finalyHealth >= _maxHealth)
        {
            Health = _maxHealth;
        }
        else
        {
            Health += healthCount;
        }
    }

    public void StartAttackCooldown()
    {
        StartCoroutine(AttackCooldownRoutine());
    }

    private IEnumerator AttackCooldownRoutine()
    {
        CanAttack = false;
        yield return new WaitForSeconds(_cooldown);
        CanAttack = true;
    }
}
