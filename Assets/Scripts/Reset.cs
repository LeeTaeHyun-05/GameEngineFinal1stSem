using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Reset : MonoBehaviour
{
    public void OnClickResetAll()
    {
        // 골드 삭제
        string goldPath = Application.persistentDataPath + "/gold.json";
        if (File.Exists(goldPath)) File.Delete(goldPath);


        // 업그레이드 삭제
        string upgradePath = Application.persistentDataPath + "/upgrades.json";
        if (File.Exists(upgradePath)) File.Delete(upgradePath);

        // 점수판 삭제 (선택 사항)
        string scorePath = Application.persistentDataPath + "/scores.json";
        if (File.Exists(scorePath)) File.Delete(scorePath);
        UpgradeManager.Instance.LoadUpgrades();
    }


}
