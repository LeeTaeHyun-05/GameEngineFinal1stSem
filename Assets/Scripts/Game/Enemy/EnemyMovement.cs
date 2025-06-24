using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private EnemyStatData stats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<EnemyStatData>();
    }

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * stats.statData.moveSpeed;
    }
}
