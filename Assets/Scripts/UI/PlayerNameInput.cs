using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNameInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public static string PlayerName { get; private set; }

    public void OnConfirmName()
    {
        PlayerName = string.IsNullOrWhiteSpace(inputField.text) ? "플레이어" : inputField.text;
        Debug.Log($"[이름 확인] 입력한 이름: {PlayerName}");
        SceneManager.LoadScene("GameScene");
    }

}
