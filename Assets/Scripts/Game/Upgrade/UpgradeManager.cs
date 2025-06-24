using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class UpgradeData
{

    public int atkLevel = 0;
    public int defLevel = 0;
    public int hpLevel = 0;


    public int GetUpgradeCost(int level) => 150 + (level * 100);
}

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    public PlayerStatSO playerStat;
    public GoldData goldData;
    public UpgradeData upgradeData = new UpgradeData();

    public int maxLevel = 5;
  

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadUpgrades();
    }

    public int GetUpgradeCost(int level)
    {
        return 150 + (level * 100); // 0→1 : 150, 1→2 : 250, ...
    }

    public void UpgradeAttack()
    {
        int level = upgradeData.atkLevel;
        if (level >= maxLevel) return;

        int cost = GetUpgradeCost(level);
        if (goldData.currentGold < cost) return;

        goldData.currentGold -= cost;
        playerStat.baseAttack += 1;
        upgradeData.atkLevel++;
        SaveUpgrades();
      

    }

    public void UpgradeDefense()
    {
        int level = upgradeData.defLevel;
        if (level >= maxLevel) return;

        int cost = GetUpgradeCost(level);
        if (goldData.currentGold < cost) return;

        goldData.currentGold -= cost;
        playerStat.baseDefense += 1;
        upgradeData.defLevel++;
        SaveUpgrades();
    }

    public void UpgradeHP()
    {
        int level = upgradeData.hpLevel;
        if (level >= maxLevel) return;

        int cost = GetUpgradeCost(level);
        if (goldData.currentGold < cost) return;

        goldData.currentGold -= cost;
        playerStat.baseHP += 10;
        upgradeData.hpLevel++;
        SaveUpgrades();
    }

    public void SaveUpgrades()
    {
        string json = JsonUtility.ToJson(upgradeData);
        File.WriteAllText(Application.persistentDataPath + "/upgrades.json", json);
    }

    public void LoadUpgrades()
    {
        string path = Application.persistentDataPath + "/upgrades.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            upgradeData = JsonUtility.FromJson<UpgradeData>(json);
        }
    }
    public string GetUpgradeSummary(string statType)
    {
        int level = 0;
        switch (statType)
        {
            case "ATK": level = upgradeData.atkLevel; break;
            case "DEF": level = upgradeData.defLevel; break;
            case "HP": level = upgradeData.hpLevel; break;
        }

        if (level >= maxLevel)
            return "MAX 강화 완료";

        int cost = GetUpgradeCost(level);
        return $"Lv.{level} → Lv.{level + 1}   |   비용: {cost:N0}G";
    }


}
