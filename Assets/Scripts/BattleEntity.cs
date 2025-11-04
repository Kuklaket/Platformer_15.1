using UnityEngine;

public class BattleEntity : MonoBehaviour
{
    protected Stats CharacterStats { get; private set; }

    private void Awake()
    {
        CharacterStats = GetComponent<Stats>();
    }

    private void OnEnable()
    {
        CharacterStats.Died += Die;
    }
    private void OnDisable()
    {
        CharacterStats.Died -= Die;
    } 

    public void HandlerDamage(int damageCount)
    {
        CharacterStats.GetDamage(damageCount);
    }

    public int GetAttack()
    {
        return CharacterStats.Attack;
    }

    protected void Die()
    {
        gameObject.SetActive(false);
    }
}
