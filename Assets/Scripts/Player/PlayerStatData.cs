using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerStatData : MonoBehaviour
{
    public PlayerStatSO statData;
    public int CurrentHealth { get; private set; }
    public int Attack => statData.attack;
    public int Defense => statData.defense;
    public float AttackSpeed => statData.attackSpeed;
    public float MoveSpeed => statData.moveSpeed;

    private void Awake()
    {
        CurrentHealth = statData.maxHealth;
    }

    public void TakeDamage(int damage)
    {
        int finalDamage = Mathf.Max(damage - Defense, 1);
        CurrentHealth -= finalDamage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + amount, statData.maxHealth);
    }

    private void Die()
    {
        GameManager.Instance.PlayerDied();
        Debug.Log("플레이어 사망");
    }
}
