using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimDirection : MonoBehaviour
{
    public Transform bodyToRotate;     
    public Transform weaponToRotate;
    private void Update()
    {
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorld - (Vector2)transform.position).normalized;

        // 좌우 회전 기준 (FlipX)
        if (bodyToRotate != null)
        {
            SpriteRenderer sr = bodyToRotate.GetComponent<SpriteRenderer>();
            sr.flipX = direction.x < 0;
        }

        // 무기 회전 적용 (정밀도용)
        if (weaponToRotate != null)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            weaponToRotate.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
