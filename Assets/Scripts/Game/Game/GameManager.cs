using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


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
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        LoadGold();
    }

    private void Start()
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
        gameOverUI.SetActive(true);
    }

    private void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = $"GOLD: {goldData.currentGold}";
        }
    }

    private void SaveGold()
    {
        string json = JsonUtility.ToJson(goldData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/gold.json", json);
    }

    private void LoadGold()
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
}
