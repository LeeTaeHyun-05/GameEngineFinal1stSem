using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public PlayerStatSO player;
    public GoldData goldData;
    public TextMeshProUGUI goldText;
    public EXPSystem expSystem;
    public GameObject gameOverUI; 
    public int Score { get; private set; }
    public int CurrentWave { get; private set; }

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGold();

    }

    public void Start()
    {
        UpdateGoldUI();
    }

    public void AddGold(int amount)
    {
        goldData.currentGold += amount;
        UpdateGoldUI();
        SaveGold();
    }

    public void PlayerDied()
    {
       
        Time.timeScale = 0f;

        string playerName = PlayerPrefs.GetString("PlayerName", "�÷��̾�");


        ScoreEntry entry = new ScoreEntry
        {
            playerName = playerName,
            wave = CurrentWave,
            score = Score,
            survivalTime = Time.timeSinceLevelLoad
        };
        Debug.Log($"[���� ����] �̸�: {entry.playerName} | ����: {entry.score}");
        Scoremanager.Instance.SaveScore(entry);

        if (gameOverUI != null)
            gameOverUI.SetActive(true);
        else
            Debug.LogError("GameOverUI�� GameManager�� ������� �ʾҽ��ϴ�!");

    }

    public void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = $"GOLD: {goldData.currentGold}";
        }
    }

    public void SaveGold()
    {
        string json = JsonUtility.ToJson(goldData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/gold.json", json);
    }

    public void LoadGold()
    {
        string path = Application.persistentDataPath + "/gold.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, goldData);
        }
    }
    public void AddScore(int value)
    {
        Score += value;
    }
    public void SetWave(int wave)
    {
        CurrentWave = wave;
    }
    public void ResetGoldCompletely()
    {
        string path = Application.persistentDataPath + "/gold.json";
        if (System.IO.File.Exists(path))
            System.IO.File.Delete(path); // 1. ���� ����

        goldData.currentGold = 0;        // 2. �޸� ���� ���� �ʱ�ȭ
        SaveGold();                      // 3. �� �� �ٽ� ����
        UpdateGoldUI();                  // 4. UI�� ����
    }

    public void ResetGame()
    {
        Score = 0;
        CurrentWave = 0;
        Time.timeScale = 1f;

        if (expSystem != null)
        {
            expSystem.currentExp = 0;
            expSystem.currentLevel = 1;
            expSystem.expSlider.value = 0;
        }

        if (UIController.Instance != null)
        {
            UIController.Instance.OnScoreChanged(0);
            UIController.Instance.OnGoldChanged(goldData.currentGold);
        }

        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

}
