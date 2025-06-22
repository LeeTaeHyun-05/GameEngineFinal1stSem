using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 2)]
public class EnemyStatSO : ScriptableObject
{
    public int maxHealth = 10;
    public int attack = 3;
    public int defense = 1;
    public float moveSpeed = 0.75f;
    public int goldReward = 1;
    public int expReward = 5;
}
