
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerStat", menuName = "ScriptableObjects/PlayerStat", order = 1 )]
public class PlayerStatSO : ScriptableObject
{
    public int maxHealth = 15;
    public int attack = 5;
    public int defense = 3;
    public float attackSpeed = 0.5f;
    public float moveSpeed = 1f;
}
