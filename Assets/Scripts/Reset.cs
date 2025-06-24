using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Reset : MonoBehaviour
{
    public void OnClickResetAll()
    {
        // ��� ����
        string goldPath = Application.persistentDataPath + "/gold.json";
        if (File.Exists(goldPath)) File.Delete(goldPath);


        // ���׷��̵� ����
        string upgradePath = Application.persistentDataPath + "/upgrades.json";
        if (File.Exists(upgradePath)) File.Delete(upgradePath);

        // ������ ���� (���� ����)
        string scorePath = Application.persistentDataPath + "/scores.json";
        if (File.Exists(scorePath)) File.Delete(scorePath);
        UpgradeManager.Instance.LoadUpgrades();
    }


}
