using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EXPSystem : MonoBehaviour
{
    public int currentExp = 0;
    public int currentLevel = 1;
    private int expToNextLevel = 100;
    public Slider expSlider;
    public GameObject upgradeUI;



    public void GainExp (int amount)
    {
        expSlider.value = (float) currentExp / expToNextLevel;

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
        expToNextLevel = GetCurrentLevelRequirement();
        Debug.Log($"���� ��! ���� ����: {currentLevel}");
        Time.timeScale = 0f; // �Ͻ� ����
        upgradeUI.SetActive(true);

    }
    public int GetCurrentLevelRequirement()
    {
        return 100 + (currentLevel - 1) * 20;
    }

}
