using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1.2f;
    public float attackCooldown = 1.5f;
    public LayerMask playerLayer;

    private float currentCooldown = 0f;
    private EnemyStatData stats;

    private void Awake()
    {
        stats = GetComponent<EnemyStatData>();
    }

    private void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown <= 0f)
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRange, playerLayer);
            if (hit != null && hit.CompareTag("Player"))
            {
                PlayerStatData player = hit.GetComponent<PlayerStatData>();
                if (player != null)
                {
                    int damage = Mathf.Max(stats.statData.attack - player.Defense, 1);
                    player.TakeDamage(damage);
                    currentCooldown = attackCooldown;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
