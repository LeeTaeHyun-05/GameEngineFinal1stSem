using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPSystem : MonoBehaviour
{
    public int currentExp = 0;
    public int currentLevel = 1;
    private int expToNextLevel = 20;

    public void GainExp (int amount)
    {
        currentExp += amount;
        while (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;
            LevelUP();
        }
    }    

    private void LevelUP()
    {
        currentLevel++;
        expToNextLevel += 20;
        Debug.Log($"���� ��! ���� ����: {currentLevel}");
    }
    public int GetCurrentLevelRequirement()
    {
        return 100 + (currentLevel - 1) * 20;
    }

}
