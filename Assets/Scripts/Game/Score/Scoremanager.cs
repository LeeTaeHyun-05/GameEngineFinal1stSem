using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int wave;
    public int score;
    public float survivalTime;
}


public class Scoremanager : MonoBehaviour
{
    public List<ScoreEntry> entries = new List<ScoreEntry>();
    private string filePath => Application.persistentDataPath + "/scores.json";
    public static Scoremanager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScores();
    }



    public void SaveScore(ScoreEntry entry)
    {
        LoadScores();
        entries.Add(entry);
        SaveToFile();
    }

    public List<ScoreEntry> GetSortedScores()
    {
        return entries.OrderByDescending(e => e.score)
                      .ThenByDescending(e => e.survivalTime).ToList();
    }

    private void LoadScores()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            entries = JsonUtility.FromJson<Wrapper>(json)?.entries ?? new List<ScoreEntry>();
        }
    }


    private void SaveToFile()
    {
        string json = JsonUtility.ToJson(new Wrapper { entries = entries });
        File.WriteAllText(filePath, json);

    }

    [System.Serializable]
    private class Wrapper { public List<ScoreEntry> entries; }

}
