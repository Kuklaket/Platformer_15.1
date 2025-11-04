using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(CharacterAnimator))]
public class Player : BattleEntity
{
    [SerializeField] private Collector _collector;

    public void Heal(int healthCount)
    {
        CharacterStats.AddHealth(healthCount);
    }
}