using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuInitializer : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    void Start()
    {
        GameManager.Instance.goldText = goldText;

        GameManager.Instance.UpdateGoldUI();
    }
}


