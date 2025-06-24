using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerStatData : MonoBehaviour
{
    public PlayerStatSO statData;
    public int CurrentHealth { get; private set; }
    // ���ʽ� ���� (������ �� ����)
    public int BonusAttack { get; set; }
    public int BonusDefense { get; set; }
    public int BonusMaxHealth { get; set; }
    public float BonusAttackSpeed { get; set; }
    public float BonusMoveSpeed { get; set; }

    // ���� ���� ������Ƽ
    public int Attack => statData.attack + BonusAttack;
    public int Defense => statData.defense + BonusDefense;
    public float AttackSpeed => statData.attackSpeed + BonusAttackSpeed;
    public float MoveSpeed => statData.moveSpeed + BonusMoveSpeed;
  

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
        Debug.Log("�÷��̾� ���");
    }
}
