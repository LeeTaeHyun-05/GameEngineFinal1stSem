using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatData : MonoBehaviour
{
    public EnemyStatSO statData;
    public int CurrentHealth { get; private set; }
    public int Defense => statData.defense;

    private void Awake()
    {
        CurrentHealth = statData.maxHealth;
    }

    public void TakeDamage(int damage)
    {
        int finalDamage = Mathf.Max(damage - statData.defense, 1);
        CurrentHealth -= finalDamage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} »ç¸Á, °ñµå +{statData.goldReward}, °æÇèÄ¡ +{statData.expReward}");

        GameManager.Instance.AddGold(statData.goldReward);
        GameManager.Instance.expSystem.GainExp(statData.expReward);
        Destroy(gameObject);
    }
}
