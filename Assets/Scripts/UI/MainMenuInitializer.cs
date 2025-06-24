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

        if (goldText != null)
        {
            GameManager.Instance.UpdateGoldUI();
        }
        else
        {
            Debug.LogWarning("goldText�� MainMenuInitializer���� null�Դϴ�.");
        }
    }

}
