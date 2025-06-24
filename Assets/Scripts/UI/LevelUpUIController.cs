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
            Debug.Log($"[������] ���ݷ� ����: �� {playerStats.Attack}");
            HidePanel();
        });

        defButton.onClick.AddListener(() => {
            playerStats.BonusDefense += 1;
            Debug.Log($"[������] ���� ����: �� {playerStats.Defense}");
            HidePanel();
        });

        hpButton.onClick.AddListener(() => {
            playerStats.BonusMaxHealth += 5;
            playerStats.Heal(5);
            Debug.Log($"[������] ü�� ����: �� {playerStats.CurrentHealth}/{playerStats.statData.maxHealth + playerStats.BonusMaxHealth}");
            HidePanel();
        });

        moveSpeedButton.onClick.AddListener(() => {
            playerStats.BonusMoveSpeed += 0.5f;
            Debug.Log($"[������] �̵��ӵ� ����: �� {playerStats.MoveSpeed}");
            HidePanel();
        });

        atkSpeedButton.onClick.AddListener(() => {
            playerStats.BonusAttackSpeed += 0.3f;
            Debug.Log($"[������] ���ݼӵ� ����: �� {playerStats.AttackSpeed}");
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
