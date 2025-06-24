using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIController : MonoBehaviour
{
    public GameObject shopPanel;
    public TextMeshProUGUI atkText, defText, hpText;
    public Button atkButton, defButton, hpButton;

    void OnEnable() => UpdateUI();

    public void OpenShop() => shopPanel.SetActive(true);
    public void CloseShop() => shopPanel.SetActive(false);

    public void OnClickUpgradeHP()
    {
        UpgradeManager.Instance.UpgradeHP();
        UpdateUI();
    }

    public void OnClickUpgradeAttack()
    {
        UpgradeManager.Instance.UpgradeAttack();
        UpdateUI();
    }

    public void OnClickUpgradeDefense()
    {
        UpgradeManager.Instance.UpgradeDefense();
        UpdateUI();
    }

    void UpdateUI()
    {
        var mgr = UpgradeManager.Instance;
        var gold = mgr.goldData.currentGold;

        atkText.text = mgr.GetUpgradeSummary("ATK");
        defText.text = mgr.GetUpgradeSummary("DEF");
        hpText.text = mgr.GetUpgradeSummary("HP");

        atkButton.interactable = mgr.upgradeData.atkLevel < mgr.maxLevel &&
                                 gold >= mgr.GetUpgradeCost(mgr.upgradeData.atkLevel);

        defButton.interactable = mgr.upgradeData.defLevel < mgr.maxLevel &&
                                 gold >= mgr.GetUpgradeCost(mgr.upgradeData.defLevel);

        hpButton.interactable = mgr.upgradeData.hpLevel < mgr.maxLevel &&
                                 gold >= mgr.GetUpgradeCost(mgr.upgradeData.hpLevel);
    }


}


