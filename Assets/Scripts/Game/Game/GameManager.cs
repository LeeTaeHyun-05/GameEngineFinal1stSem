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
        ScoreEntry entry = new ScoreEntry
        {
            playerName = "Taehyun", // 또는 이름 입력창에서 받은 값
            wave = CurrentWave,
            score = Score,
            survivalTime = Time.timeSinceLevelLoad
        };
        Scoremanager.Instance.SaveScore(entry);

        Time.timeScale = 0f;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        else
        {
            Debug.LogError("GameOverUI가 GameManager에 연결되지 않았습니다!");
        }

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
            System.IO.File.Delete(path); // 1. 파일 삭제

        goldData.currentGold = 0;        // 2. 메모리 상의 값도 초기화
        SaveGold();                      // 3. 빈 값 다시 저장
        UpdateGoldUI();                  // 4. UI도 갱신
    }

}
