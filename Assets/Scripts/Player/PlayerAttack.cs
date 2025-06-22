using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatSO))]
public class PlayerAttack : MonoBehaviour
{
    public Transform attackOrigin; // 공격 시작 위치
    public float attackRange = 2f; // 공격 범위
    public float attackAngle = 120f; // 공격 각도
    public LayerMask enemyLayer;

    private PlayerStatData stats;
    private bool isAttacking = false;

    private void Awake()
    {
        stats = GetComponent<PlayerStatData>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(AttackRoutine());
        }
    }

    private IEnumerator AttackRoutine()
    {
        if (isAttacking) yield break;

        isAttacking = true;
        PerformAttack();
        yield return new WaitForSeconds(1f / stats.statData.attackSpeed);
        isAttacking = false;

        // 자동 공격
        while (Input.GetMouseButton(0))
        {
            PerformAttack();
            yield return new WaitForSeconds(1f / stats.statData.attackSpeed);
        }
    }

    private void PerformAttack()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackOrigin.position, attackRange, enemyLayer);

        foreach (var hit in hits)
        {
            Vector2 toTarget = ((Vector2)hit.transform.position - (Vector2)attackOrigin.position).normalized;
            float angle = Vector2.Angle(direction, toTarget);

            if (angle <= attackAngle * 0.5f)
            {
                EnemyStatData enemy = hit.GetComponent<EnemyStatData>();
                if (enemy != null)
                {
                    enemy.TakeDamage(stats.statData.attack);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackOrigin == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackOrigin.position, attackRange);
    }
}
