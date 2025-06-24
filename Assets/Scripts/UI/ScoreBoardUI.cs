
using TMPro;
using UnityEngine;


public class ScoreBoardUI : MonoBehaviour
{
    public Transform content;
    public GameObject itemPrefab;
    public Scoremanager scoreManager;

    private void Start()
    {
        scoreManager.LoadScores();
        var sorted = scoreManager.GetSortedScores();

        foreach (var entry in sorted)
        {
            GameObject item = Instantiate(itemPrefab, content);
            var texts = item.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = entry.playerName;
            texts[1].text = $"{entry.wave}웨이브";
            texts[2].text = $"{entry.score}점";
            texts[3].text = $"{entry.survivalTime:F1}초";
        }
    }
}
