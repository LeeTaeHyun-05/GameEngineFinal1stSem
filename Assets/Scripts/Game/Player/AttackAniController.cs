using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAniController : MonoBehaviour
{
    private Animator weaponAnimator;
    private SpriteRenderer weaponRenderer;

    [SerializeField] private PlayerMovement playerMovement;

    private void Awake()
    {
        weaponAnimator = GetComponent<Animator>();
        weaponRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 dir = playerMovement.lastDirection;

        weaponAnimator.SetFloat("MoveX", dir.x);
        weaponAnimator.SetFloat("MoveY", dir.y);

        // Flip ¹«±â Sprite
        if (dir.x < -0.5f)
            weaponRenderer.flipX = true;
        else if (dir.x > 0.5f)
            weaponRenderer.flipX = false;
    }

    public void PlayAttackAnimation()
    {
        weaponAnimator.SetTrigger("IsAttack");
    }
}
