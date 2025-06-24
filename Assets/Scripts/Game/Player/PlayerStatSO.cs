
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerStat", menuName = "ScriptableObjects/PlayerStat", order = 1 )]
public class PlayerStatSO : ScriptableObject
{
    public int maxHealth = 15;
    public int attack = 5;
    public int defense = 3;
    public float attackSpeed = 0.5f;
    public float moveSpeed = 1f;
    
    public int baseHP = 15;
    public int baseAttack = 5;
    public int baseDefense = 3;
    public int hpLevel = 0;
    public int atkLevel = 0;
    public int defLevel = 0;


}



