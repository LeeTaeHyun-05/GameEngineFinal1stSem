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
            GameManager.Instance.gameOverUI = gameOverUI;
            Debug.Log("GameOverUI ø¨∞·µ : " + gameOverUI.name);
        }
        else
        {
            Debug.LogWarning("GameManager.Instance∞° null¿”!");
        }


    }

}
