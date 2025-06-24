
using UnityEngine;


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
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(scoreValue);
            GameManager.Instance.AddGold(statData.goldReward);
            GameManager.Instance.expSystem?.GainExp(statData.expReward);
        }

        DropExpOrb();
        Destroy(gameObject);
    }



private void DropExpOrb()
    {
        float chance = Random.value;
        GameObject orbToDrop = (chance <= 0.8f) ? expOrb10 : expOrb30;
        Instantiate(orbToDrop, transform.position, Quaternion.identity);
    }
}
