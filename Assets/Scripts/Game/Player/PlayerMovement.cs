using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerStatData))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerStatData stats;

    private Vector2 input;
    public Vector2 lastDirection = Vector2.down;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        stats = GetComponent<PlayerStatData>();
    }

    private void Update()
    {
        HandleInput();
        HandleAnimation();
        HandleSpriteFlip();
    }

    private void FixedUpdate()
    {
        rb.velocity = input * stats.MoveSpeed;
    }

    private void HandleInput()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (input != Vector2.zero)
            lastDirection = input;
    }

    private void HandleAnimation()
    {
        bool isMoving = input != Vector2.zero;
        animator.SetBool("IsMoving", isMoving);

        // 방향 전달 (정지 상태에서도 방향 유지)
        animator.SetFloat("MoveX", lastDirection.x);
        animator.SetFloat("MoveY", lastDirection.y);

    }

    private void HandleSpriteFlip()
    {
        if (lastDirection.x < -0.5f)
            spriteRenderer.flipX = true;
        else if (lastDirection.x > 0.5f)
            spriteRenderer.flipX = false;
    }
}
