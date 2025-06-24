using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    public int expValue = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EXPSystem expSystem = FindObjectOfType<EXPSystem>();
            if (expSystem != null)
            {
                expSystem.GainExp(expValue);
                Destroy(gameObject);
            }
        }
    }

}
