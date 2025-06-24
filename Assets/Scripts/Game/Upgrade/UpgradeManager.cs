using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UpgradeData
{

    public int atkLevel = 0;
    public int defLevel = 0;
    public int hpLevel = 0;


    public int GetUpgradeCost(int level) => 100 + level * 80;
}

public class UpgradeManager : MonoBehaviour
{
    public PlayerStatSO playerStat;
    public GoldData goldData;
    public UpgradeData upgradeData = new UpgradeData();
    public static UpgradeManager Instance { get; private set; }
    private const int maxLevel = 5;

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
    private void Start()
    {
        ApplyUpgrades();
    }




    public void UpgradeAttack()
    {
        TryUpgrade(ref upgradeData.atkLevel, () => playerStat.attack++);
    }

    public void UpgradeDefense()
    {
        TryUpgrade(ref upgradeData.defLevel, () => playerStat.defense++);
    }

    public void UpgradeHP()
    {
        TryUpgrade(ref upgradeData.hpLevel, () => playerStat.maxHealth += 3);
    }

    private void TryUpgrade(ref int level, System.Action onUpgrade)
    {
        if (level >= maxLevel) return;

        int cost = upgradeData.GetUpgradeCost(level);
        if (goldData.currentGold >= cost)
        {
            goldData.currentGold -= cost;
            level++;
            onUpgrade?.Invoke();
            SaveUpgrades();
        }
    }

    private void ApplyUpgrades()
    {
        playerStat.attack += upgradeData.atkLevel;
        playerStat.defense += upgradeData.defLevel;
        playerStat.maxHealth += upgradeData.hpLevel * 3;
    }

    private void SaveUpgrades()
    {
        string json = JsonUtility.ToJson(upgradeData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/upgrade.json", json);
    }

    private void LoadUpgrades()
    {
        string path = Application.persistentDataPath + "/upgrade.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            upgradeData = JsonUtility.FromJson<UpgradeData>(json);
        }
    }
}
