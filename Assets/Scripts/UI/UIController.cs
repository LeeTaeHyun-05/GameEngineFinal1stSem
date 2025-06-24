using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timeText;
    public Slider expSlider;
    public Slider hpSlider;

    [Header("References")]
    public PlayerStatData player;
    public EXPSystem expSystem;
    public GoldData goldData;

    private float timer = 0f;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    private void Update()
    {
        timer += Time.deltaTime;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (player != null && player.statData != null && hpSlider != null)
            hpSlider.value = (float)player.CurrentHealth / player.statData.maxHealth;

        if (expSystem != null && expSlider != null)
            expSlider.value = (float)expSystem.currentExp / expSystem.GetCurrentLevelRequirement();

        if (scoreText != null)
            scoreText.text = $"����: {GameManager.Instance?.Score ?? 0}";

        if (goldText != null && goldData != null)
            goldText.text = $"���: {goldData.currentGold}";

        if (waveText != null)
            waveText.text = $"���̺�: {GameManager.Instance?.CurrentWave ?? 0}";

        if (timeText != null)
            timeText.text = $"���� �ð�: {timer:F1}��";
    }

    public void OnScoreChanged(int score)
    {
        scoreText.text = $"����: {score}";
    }
    public void OnGoldChanged(int newGold)
    {
        if (goldText != null)
            goldText.text = $"GOLD: {newGold}";
    }

}


