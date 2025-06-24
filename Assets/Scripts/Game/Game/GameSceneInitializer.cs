using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneInitializer : MonoBehaviour
{
    public GameObject gameOverUI;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.goldData.currentGold = 0; // ��� �ʱ�ȭ
            GameManager.Instance.UpdateGoldUI();           // UI ����
            GameManager.Instance.gameOverUI = gameOverUI;
            GameManager.Instance.expSystem = FindObjectOfType<EXPSystem>();
        }


    }

}
