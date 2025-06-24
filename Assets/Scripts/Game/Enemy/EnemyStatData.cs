using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatData : MonoBehaviour
{

    [Header("Drop")]
    public GameObject expOrb10;
    public GameObject expOrb30;

    public int scoreValue = 100;

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
        // 1. ���� ȹ��
        GameManager.Instance.AddScore(scoreValue); // ���� ����
        UIController.Instance.OnScoreChanged(GameManager.Instance.Score); // UI �ݿ�

        // 2. ��� ȹ��
        GameManager.Instance.AddGold(statData.goldReward);

        // 3. ����ġ ȹ��
        GameManager.Instance.expSystem.GainExp(statData.expReward);

        // 4. ����ġ ������Ʈ ���
        DropExpOrb();

        // 5. �� ����
        Destroy(gameObject);
    }



private void DropExpOrb()
    {
        float chance = Random.value;
        GameObject orbToDrop = (chance <= 0.8f) ? expOrb10 : expOrb30;
        Instantiate(orbToDrop, transform.position, Quaternion.identity);
    }
}
