using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatData))]

public class PlayerAttack : MonoBehaviour
{
    public Transform attackOrigin; // ���� ���� ��ġ
    public float attackRange = 1f; // ���� ����
    public float attackAngle = 90f; // ���� ����
    public LayerMask enemyLayer;

    private PlayerStatData stats;
    private bool isAttacking = false;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private AttackAniController weaponAnimator;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        stats = GetComponent<PlayerStatData>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (!isAttacking && Input.GetMouseButton(0))
        {
            StartCoroutine(AttackRoutine());
        }
        if (Input.GetMouseButtonDown(0)) // ��Ŭ��
        {
            weaponAnimator.PlayAttackAnimation();
        }

    }

    private IEnumerator AttackRoutine()
    {
        if (isAttacking) yield break;

        isAttacking = true;
        PerformAttack();
        yield return new WaitForSeconds(1f / stats.statData.attackSpeed);
        isAttacking = false;

        // �ڵ� ����
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
                    enemy.TakeDamage(stats.Attack);
                }
            }
        }
        Debug.Log("���� �����");

    }

    private void OnDrawGizmosSelected()
    {
        if (attackOrigin == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackOrigin.position, attackRange);
    }
}
