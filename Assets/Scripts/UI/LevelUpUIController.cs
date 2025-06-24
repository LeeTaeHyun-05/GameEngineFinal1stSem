using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUIController : MonoBehaviour
{
    public GameObject levelUpPanel;

    public Button atkButton;
    public Button defButton;
    public Button hpButton;
    public Button moveSpeedButton;
    public Button atkSpeedButton;

    private PlayerStatData playerStats;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStatData>();
        HidePanel();

        atkButton.onClick.AddListener(() => {
            playerStats.BonusAttack += 2;
            Debug.Log($"[레벨업] 공격력 증가: 총 {playerStats.Attack}");
            HidePanel();
        });

        defButton.onClick.AddListener(() => {
            playerStats.BonusDefense += 1;
            Debug.Log($"[레벨업] 방어력 증가: 총 {playerStats.Defense}");
            HidePanel();
        });

        hpButton.onClick.AddListener(() => {
            playerStats.BonusMaxHealth += 5;
            playerStats.Heal(5);
            Debug.Log($"[레벨업] 체력 증가: 총 {playerStats.CurrentHealth}/{playerStats.statData.maxHealth + playerStats.BonusMaxHealth}");
            HidePanel();
        });

        moveSpeedButton.onClick.AddListener(() => {
            playerStats.BonusMoveSpeed += 0.5f;
            Debug.Log($"[레벨업] 이동속도 증가: 총 {playerStats.MoveSpeed}");
            HidePanel();
        });

        atkSpeedButton.onClick.AddListener(() => {
            playerStats.BonusAttackSpeed += 0.3f;
            Debug.Log($"[레벨업] 공격속도 증가: 총 {playerStats.AttackSpeed}");
            HidePanel();
        });
    }

    public void ShowPanel()
    {
        Time.timeScale = 0f;
        levelUpPanel.SetActive(true);
    }

    public void HidePanel()
    {
        Time.timeScale = 1f;
        levelUpPanel.SetActive(false);
    }
}
