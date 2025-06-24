using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerStatData stats;
    private Vector2 input;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        stats = GetComponent<PlayerStatData>();
    }

    private void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // �ִϸ����Ϳ� ����� ������ ���� ����
        animator.SetFloat("MoveX", input.x);
        animator.SetFloat("MoveY", input.y);
        animator.SetBool("IsMoving", input != Vector2.zero);

        // ������ �� sprite ����
        if (input.x < 0)
            spriteRenderer.flipX = true;
        else if (input.x > 0)
            spriteRenderer.flipX = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = input * stats.statData.moveSpeed;
    }
}
